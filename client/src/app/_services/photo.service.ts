import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Photo } from '../_models/photo';

@Injectable({
  providedIn: 'root'
})
export class PhotoService {
  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }


  create(model: FormData) {
    return this.http.post<Photo>(this.baseUrl + "/photo", model);
  }

  getPhotoById() {
    return this.http.get<Photo[]>(this.baseUrl)
  }

  setMainPhoto(photoId: number) {
    return this.http.put(this.baseUrl + "user/set-main-photo/" + photoId, {})
  }
  
  deletePhoto(photoId: number) {
    return this.http.delete(this.baseUrl + 'user/delete-photo/' + photoId);
  }
}
