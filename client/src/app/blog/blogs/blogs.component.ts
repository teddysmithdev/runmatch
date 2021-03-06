import { Component, OnInit } from '@angular/core';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';
import { Blog } from 'src/app/_models/blog';
import { BlogParams } from 'src/app/_models/blogParams';
import { Pagination } from 'src/app/_models/pagination';
import { BlogService } from 'src/app/_services/blog.service';


@Component({
  selector: 'app-blogs',
  templateUrl: './blogs.component.html',
  styleUrls: ['./blogs.component.css']
})
export class BlogsComponent implements OnInit {
  blogParams: BlogParams = new BlogParams();
  pagination: Pagination;
  blogs: Blog[];

  constructor(
    private blogService: BlogService
  ) { }

  ngOnInit(): void {
    this.loadBlogs();
  }

  pageChanged(event: any) {
    this.blogParams.pageNumber = event.page;
    // this.memberService.setUserParams(this.userParams);
    this.loadBlogs();
  }
  
  loadBlogs() {
    this.blogService.getBlogs(this.blogParams).subscribe(pagedBlogs => {
      this.blogs = pagedBlogs.result;
    });
  }

}
