import { Injectable } from '@angular/core';
import {
  Router, Resolve,
  RouterStateSnapshot,
  ActivatedRouteSnapshot
} from '@angular/router';
import { Observable, of } from 'rxjs';
import { take } from 'rxjs/operators';
import { IpAddress } from '../_models/ipaddress';
import { AccountService } from '../_services/account.service';

@Injectable({
  providedIn: 'root'
})
export class LocationResolver implements Resolve<IpAddress> {
  constructor(private accountService: AccountService) {

  }
  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<IpAddress> {
    return this.accountService.getIPAddress().pipe(take(1));
  }
}
