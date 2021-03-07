import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Event } from '../_models/event';

@Injectable({
  providedIn: 'root'
})
export class EventService {

  baseUrl = environment.apiUrl

  constructor(private http: HttpClient) { }
  
  getEvents(): Observable<Event[]> {
    return this.http.get<Event[]>(this.baseUrl + "event");
  }
}
