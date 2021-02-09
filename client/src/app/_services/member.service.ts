import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ok } from 'assert';
import { Observable, of, pipe } from 'rxjs';
import { map } from 'rxjs/internal/operators/map';
import { take, tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Member } from '../_models/member';
import { PaginatedResult } from '../_models/pagination';
import { User } from '../_models/user';
import { UserParams } from '../_models/userParams';
import { AccountService } from './account.service';
import { getPaginatedResult, getPaginationHeaders } from './paginationHelper';


@Injectable({
  providedIn: 'root'
})
export class MemberService {
  baseUrl = environment.apiUrl;
  members: Member[] = [];
  paginatedResult: PaginatedResult<Member[]> = new PaginatedResult<Member[]>();
  memberCache = new Map();
  user: User;
  userParams: UserParams;
  


constructor(private http: HttpClient, private accountService: AccountService) { 
  this.accountService.currentUser$.pipe(take(1)).subscribe(user => {
    this.user = user;
    this.userParams = new UserParams(user);
  })
}

getUserParams() {
  return this.userParams;
}

setUserParams(params: UserParams) {
  this.userParams = params;
}

resetUserParams() {
  this.userParams = new UserParams(this.user);
  return this.userParams;
}

 getMembers(userParams: UserParams): Observable<any> {
  var response = this.memberCache.get(Object.values(userParams).join('-'));
  if (response) {
    return of(response);
  }
  let params = getPaginationHeaders(userParams.pageNumber, userParams.pageSize);

  params = params.append('minAge', userParams.minAge.toString());
  params = params.append('maxAge', userParams.maxAge.toString());
  params = params.append('gender', userParams.gender);
  params = params.append('orderBy', userParams.orderBy);

  return getPaginatedResult<Member[]>(this.baseUrl + 'user' , params, this.http)
    .pipe(map(response => {
      this.memberCache.set(Object.values(userParams).join('-'), response);
      return response;
    }))
}


getMember(username: string) {
  const member = [...this.memberCache.values()]
    .reduce((arr, elem) => arr.concat(elem.result), [])
    .find((member: Member) => member.userName === username);
  if(member) {
    return of(member);
  }
  return this.http.get<Member>(this.baseUrl + "user/" + username)
}

updateMember(member: Member) {
  return this.http.put(this.baseUrl + 'user', member).pipe(
    map(() => {
      const index = this.members.indexOf(member);
      this.members[index] = member;
    })
  );
}

setMainPhoto(photoId: number) {
  return this.http.put(this.baseUrl + "user/set-main-photo/" + photoId, {})
}

deletePhoto(photoId: number) {
  return this.http.delete(this.baseUrl + 'user/delete-photo/' + photoId);
}

addInvite(username: string) {
  return this.http.post(this.baseUrl + 'invite/' + username, {});
}

getInvites(predicate: string, pageNumber, pageSize) {
  let params = getPaginationHeaders(pageNumber, pageSize);
  params = params.append('predicate', predicate);
  return getPaginatedResult<Partial<Member[]>>(this.baseUrl + 'invite', params, this.http)
}

}
