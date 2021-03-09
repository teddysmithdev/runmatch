import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Eventt } from '../_models/eventt';
import { EventtParams } from '../_models/eventtParams';
import { PaginatedResult } from '../_models/pagination';

@Injectable({
  providedIn: 'root'
})
export class EventService {

  baseUrl = environment.apiUrl

  constructor(private http: HttpClient) { }
  
  getEvents(eventtParams: EventtParams) {
    let params = this.getPaginationHeaders(eventtParams.pageNumber, eventtParams.pageSize);
    return this.getPaginatedResult<Eventt[]>(this.baseUrl, params);
  }

  private getPaginatedResult<T>(url, params) {
    const paginatedResult: PaginatedResult<T> = new PaginatedResult<T>();
    return this.http.get<T>(url + "event", { observe: 'response', params }).pipe(
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
}
