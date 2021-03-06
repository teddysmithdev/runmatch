import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable, ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators'
import { environment } from 'src/environments/environment';
import { IpAddress } from '../_models/ipaddress';
import { User } from '../_models/user';
import { PresenceService } from './presence.service';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
baseUrl = environment.apiUrl;
private currentUserSource = new BehaviorSubject<User>(null);
currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient, private router: Router, private presence: PresenceService) { }


  login(model: any) {
    return this.http.post(this.baseUrl + 'Account/login', model).pipe(
      map((response: User) => {
        const user = response;
        if (user) {
          this.setCurrentUser(user);
          this.presence.createHubConnection(user);
        }
      })
    );
  }

  setCurrentUser(user: User) {
    user.roles = [];
    const roles = this.getDecodedToken(user.token).role;
    Array.isArray(roles) ? user.roles = roles : user.roles.push(roles);
    localStorage.setItem('user', JSON.stringify(user));
    this.currentUserSource.next(user);
  }

  register(model: any) {
    return this.http.post(this.baseUrl + 'account/register', model).pipe(
      map((user: User) => {
        if (user) {
          this.setCurrentUser(user);
          this.presence.createHubConnection(user);
        }
      })
    )
  }

  logout() {
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
    this.presence.stopHubConnection();
    this.router.navigateByUrl('')
  }

  onboardUser(user: User) {
    return this.http.put(this.baseUrl + "user/onboard/", user);
  }

  getDecodedToken(token) {
    return JSON.parse(atob(token.split('.')[1]));
  }

  getIPAddress() : Observable<IpAddress> {  
    return this.http.get<IpAddress>("https://ipinfo.io?token=63d5ada815b74c");  
  }
  
  public givenUserIsLoggedIn(username: string) {
    return this.isLoggedIn() && this.currentUser(username);
  }

  public isLoggedIn() : Observable<boolean> {
    return this.currentUser$.pipe(map(user => {
      if (user) return true;

      return false;
    }))
  }

  private currentUser(username: string) : Observable<boolean> {
    return this.currentUser$.pipe(map(user => {
      if (user.username == username) return true;

      return false;
    }))
  }

}
