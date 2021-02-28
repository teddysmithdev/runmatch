/* tslint:disable:no-unused-variable */

import { TestBed, inject, waitForAsync } from '@angular/core/testing';
import { MemberService } from './member.service';

describe('Service: Member', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [MemberService]
    });
  });

  it('should ...', inject([MemberService], (service: MemberService) => {
    expect(service).toBeTruthy();
  }));
});
