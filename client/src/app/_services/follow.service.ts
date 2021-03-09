import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Member } from '../_models/member';
import { getPaginatedResult, getPaginationHeaders } from './paginationHelper';

@Injectable({
  providedIn: 'root'
})
export class FollowService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  addFollow(username: string) {
    return this.http.post(this.baseUrl + 'follower/' + username, {});
  }

  getFollowers(predicate: string, pageNumber, pageSize) {
    let params = getPaginationHeaders(pageNumber, pageSize);
    params = params.append('predicate', predicate);
    return getPaginatedResult<Partial<Member[]>>(this.baseUrl + 'follower', params, this.http)
  }
}
