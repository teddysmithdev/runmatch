import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Club } from '../_models/club';
import { ClubParams } from '../_models/clubParams';
import { PaginatedResult } from '../_models/pagination';
import { UserParams } from '../_models/userParams';


@Injectable({
  providedIn: 'root'
})
export class ClubService {
  baseUrl = environment.apiUrl
  

constructor(private http: HttpClient) { }

getClubs(clubParams: ClubParams) {
  let params = this.getPaginationHeaders(clubParams.pageNumber, clubParams.pageSize);
  if (clubParams.city != null) {
    params = params.append("city", clubParams.city.toString());
  }
  if (clubParams.state != null) {
    params = params.append("state", clubParams.state.toString());
  }
  return this.getPaginatedResult<Club[]>(this.baseUrl, params);
}

  private getPaginatedResult<T>(url, params) {
    const paginatedResult: PaginatedResult<T> = new PaginatedResult<T>();
    return this.http.get<T>(url + "clubs", { observe: 'response', params }).pipe(
      map(response => {
        paginatedResult.result = response.body;
        if (response.headers.get('Pagination') != null) {
        paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));
        }
        return paginatedResult;
      })
    );
  }

private getPaginationHeaders(pageNumber: number, pageSize: number) {
  let params = new HttpParams();
    params = params.append('pageNumber', pageNumber.toString())
    params = params.append('pageSize', pageSize.toString())
    return params;
}

getClub(id): Observable<Club> {
  return this.http.get<Club>(this.baseUrl + "clubs/" + id);
}

createClub(club) {
  return this.http.post(this.baseUrl + "clubs/", club);
}

}