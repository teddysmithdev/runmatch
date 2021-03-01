import { Component, OnInit } from '@angular/core';
import { Member } from '../_models/member';
import { Pagination } from '../_models/pagination';
import { User } from '../_models/user';
import { MemberService } from '../_services/member.service';

@Component({
  selector: 'app-invites',
  templateUrl: './invites.component.html',
  styleUrls: ['./invites.component.scss']
})
export class InvitesComponent implements OnInit {
  members: Partial<Member[]>;
  predicate = 'invitedBy';
  pageNumber = 1;
  pageSize = 5;
  pagination: Pagination;


  constructor(private memberService: MemberService) { }

  ngOnInit() {
    this.loadInvites();
  }

  loadInvites() {
    this.memberService.getInvites(this.predicate, this.pageNumber, this.pageSize).subscribe(response => {
      this.members = response.result;
      this.pagination = response.pagination;
    })
  }

  pageChanged(event: any) {
    this.pageNumber = event.page;
    this.loadInvites();
  }

}
