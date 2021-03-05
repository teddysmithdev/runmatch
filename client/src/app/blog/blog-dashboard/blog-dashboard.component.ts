import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Blog } from 'src/app/_models/blog';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { BlogService } from 'src/app/_services/blog.service';

@Component({
  selector: 'app-blog-dashboard',
  templateUrl: './blog-dashboard.component.html',
  styleUrls: ['./blog-dashboard.component.css']
})
export class BlogDashboardComponent implements OnInit {

  userBlogs: Blog[];
  user: User;

  constructor(
    private blogService: BlogService,
    private router: Router,
    private toastr: ToastrService,
    private accountService: AccountService
  ) { 
    this.accountService.currentUser$.subscribe(u => {
      this.user = u;
  });
}

  ngOnInit(): void {
    this.userBlogs = [];

    

    this.blogService.getByBlogByUsername(this.user.username).subscribe(userBlogs => {
      this.userBlogs = userBlogs;
    });
  }

  confirmDelete(blog: Blog) {
    blog.deleteConfirm = true;
  }

  cancelDeleteConfirm(blog: Blog) {
    blog.deleteConfirm = false;
  }

  deleteConfirmed(blog: Blog, blogs: Blog[]) {
    this.blogService.delete(blog.blogId).subscribe(() => {

      let index = 0;

      for (let i=0; i<blogs.length; i++) {
        if (blogs[i].blogId === blog.blogId) {
          index = i;
        }
      }

      if (index > -1) {
        blogs.splice(index, 1);
      }

      this.toastr.info("Blog deleted.");
    });
  }

  editBlog(blogId: number) {
    this.router.navigate([`/dashboard/${blogId}`]);
  }

  createBlog() {
    this.router.navigate(['/dashboard/-1']);
  }

}
