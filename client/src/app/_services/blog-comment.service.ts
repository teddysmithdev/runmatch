import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { BlogComment } from '../_models/blogComment';
import { BlogCommentCreate } from '../_models/blogCommentCreate';

@Injectable({
  providedIn: 'root'
})
export class BlogCommentService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  createBlogComment(model: BlogCommentCreate) : Observable<BlogComment>  {
    return this.http.post<BlogComment>(this.baseUrl + 'BlogComment', model);
  }

  deleteBlogComment(blogCommentId: number) : Observable<number>  {
    return this.http.delete<number>(this.baseUrl + 'BlogComment');
  }

  getAllBlogComments(blogId: number) : Observable<BlogComment[]> {
    return this.http.get<BlogComment[]>(this.baseUrl + 'BlogComment/' + blogId);
  }
}
