import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Club } from '../_models/club';


@Injectable({
  providedIn: 'root'
})
export class ClubService {
  baseUrl = environment.apiUrl

constructor(private http: HttpClient) { }

getClubs(): Observable<Club[]> {
  return this.http.get<Club[]>(this.baseUrl + "clubs");
}

getClub(id): Observable<Club> {
  return this.http.get<Club>(this.baseUrl + "clubs/" + id);
}

createClub(club) {
  return this.http.post(this.baseUrl + "clubs/", club);
}

}