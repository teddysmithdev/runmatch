import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Blog } from '../_models/blog';
import { BlogParams } from '../_models/blogParams';
import { PaginatedResult } from '../_models/pagination';

@Injectable({
  providedIn: 'root'
})
export class BlogService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  create(model: Blog) : Observable<Blog> {
    return this.http.post<Blog>(this.baseUrl + "", model);
  }

  getBlogs(blogParams: BlogParams) : any {
    let params = this.getPaginationHeaders(blogParams.pageNumber, blogParams.pageSize);
  }

  get(blogId: number) : Observable<Blog> {
    return this.http.get<Blog>(`/Blog/${blogId}`);
  }

  getByApplicationUserId(applicationUserId: number) : Observable<Blog[]> {
    return this.http.get<Blog[]>(`/Blog/user/${applicationUserId}`);
  }

  getMostFamous() : Observable<Blog[]> {
    return this.http.get<Blog[]>(`/Blog/famous`);
  }

  delete(blogId: number) : Observable<number> {
    return this.http.delete<number>(`/Blog/${blogId}`);
  }

  private getPaginationHeaders(pageNumber: number, pageSize: number) {
    let params = new HttpParams();
      params = params.append('pageNumber', pageNumber.toString())
      params = params.append('pageSize', pageSize.toString())
      return params;
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
}
