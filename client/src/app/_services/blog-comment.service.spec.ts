import { TestBed } from '@angular/core/testing';

import { BlogCommentService } from './blog-comment.service';

describe('BlogCommentService', () => {
  let service: BlogCommentService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BlogCommentService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
