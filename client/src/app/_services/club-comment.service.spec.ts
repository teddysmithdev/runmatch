import { TestBed } from '@angular/core/testing';

import { ClubCommentService } from './club-comment.service';

describe('ClubCommentService', () => {
  let service: ClubCommentService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ClubCommentService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
