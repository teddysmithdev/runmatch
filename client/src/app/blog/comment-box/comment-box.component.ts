import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { BlogComment } from 'src/app/_models/blogComment';
import { BlogCommentCreate } from 'src/app/_models/blogCommentCreate';
import { BlogCommentViewModel } from 'src/app/_models/blogCommentView';
import { BlogCommentService } from 'src/app/_services/blog-comment.service';

@Component({
  selector: 'app-comment-box',
  templateUrl: './comment-box.component.html',
  styleUrls: ['./comment-box.component.css']
})
export class CommentBoxComponent implements OnInit {

  @Input() comment: BlogCommentViewModel;
  @Output() commentSaved = new EventEmitter<BlogComment>();

  @ViewChild('commentForm') commentForm: NgForm;

  constructor(
    private blogCommentService: BlogCommentService,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
  }

  resetComment() {
    this.commentForm.reset();
  }

  onSubmit() {

    let blogCommentCreate: BlogCommentCreate = {
      blogCommentId: this.comment.blogCommentId,
      parentBlogCommentId: this.comment.parentBlogCommentId,
      blogId: this.comment.blogId,
      content: this.comment.content
    };

    this.blogCommentService.createBlogComment(blogCommentCreate).subscribe(blogComment => {
      this.toastr.info("Comment saved.");
      this.resetComment();
      this.commentSaved.emit(blogComment);
    })
  }

}
