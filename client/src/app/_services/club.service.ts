import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Club } from '../_models/club';
import { PaginatedResult } from '../_models/pagination';


@Injectable({
  providedIn: 'root'
})
export class ClubService {
  baseUrl = environment.apiUrl
  paginatedResult: PaginatedResult<Club[]> = new PaginatedResult<Club[]>();

constructor(private http: HttpClient) { }

getClubs(page?: number, itemsPerPage?: number) {
  let params = new HttpParams();
  if (page !== null && itemsPerPage !== null) {
    params = params.append('pageNumber', page.toString())
    params = params.append('pageSize', itemsPerPage.toString())
  }
  return this.http.get<Club[]>(this.baseUrl + "clubs", {observe: 'response', params}).pipe(
    map(response => {
      this.paginatedResult.result = response.body;
      if (response.headers.get('Pagination') != null) {
        this.paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'))
      }
      return this.paginatedResult;
    })
  );
}

getClub(id): Observable<Club> {
  return this.http.get<Club>(this.baseUrl + "clubs/" + id);
}

createClub(club) {
  return this.http.post(this.baseUrl + "clubs/", club);
}

}