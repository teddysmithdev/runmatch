import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Blog } from '../_models/blog';
import { BlogCreate } from '../_models/blogCreate';
import { BlogParams } from '../_models/blogParams';
import { PaginatedResult } from '../_models/pagination';

@Injectable({
  providedIn: 'root'
})
export class BlogService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  createBlog(model: BlogCreate) : Observable<BlogCreate> {
    return this.http.post<Blog>(this.baseUrl + "blog/", model);
  }

  getBlogs(blogParams: BlogParams) : any {
    let params = this.getPaginationHeaders(blogParams.pageNumber, blogParams.pageSize);
    return this.getPaginatedResult<Blog[]>(this.baseUrl, params);
  }

  getBlog(id: any) : Observable<Blog> {
    return this.http.get<Blog>(this.baseUrl + "blog/" + id);
  }

  getByBlogByUsername(username: string) : Observable<Blog[]> {
    return this.http.get<Blog[]>(this.baseUrl + "blog/user/" + username);
  }

  // getMostFamous() : Observable<Blog[]> {
  //   return this.http.get<Blog[]>(`/Blog/famous`);
  // }

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
    return this.http.get<T>(url + "blog", { observe: 'response', params }).pipe(
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
