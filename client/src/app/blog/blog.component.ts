import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Blog } from '../_models/blog';
import { BlogService } from '../_services/blog.service';

@Component({
  selector: 'app-blog',
  templateUrl: './blog.component.html',
  styleUrls: ['./blog.component.css']
})
export class BlogComponent implements OnInit {

  blog: Blog;

  constructor(
    private blogService: BlogService,
    private route: ActivatedRoute,
    private toastr: ToastrService
  ) {
    
   }

  ngOnInit(): void {
    this.getBlog();
  }

  getBlog() {
    this.blogService.getBlog(this.route.snapshot.paramMap.get('id'))
    .subscribe(blog => {
      this.blog = blog;
    })
  }

}
