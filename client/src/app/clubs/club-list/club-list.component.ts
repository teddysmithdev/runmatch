import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Club } from 'src/app/_models/club';
import { ClubParams } from 'src/app/_models/clubParams';
import { Pagination } from 'src/app/_models/pagination';
import { ClubService } from 'src/app/_services/club.service';
import { BreadcrumbService } from 'xng-breadcrumb';

@Component({
  selector: 'app-club-list',
  templateUrl: './club-list.component.html',
  styleUrls: ['./club-list.component.css']
})
export class ClubListComponent implements OnInit {

  clubs: Club[];
  pagination: Pagination;
  clubParams: ClubParams;
  pageNumber = 1;
  pageSize = 5;

  constructor(
    private clubServce: ClubService,
    private toastr: ToastrService
    ) { }

  ngOnInit() {
    this.loadClubs();
  }

  loadClubs() {
    this.clubServce.getClubs(this.pageNumber, this.pageSize).subscribe(response => {
      this.clubs = response.result;
      this.pagination = response.pagination
    }, error => {
      this.toastr.error(error);
    })
  }


  pageChanged(event: any) {
    this.clubParams.pageNumber = event.page;
    // this.memberService.setUserParams(this.userParams);
    this.loadClubs();
  }

}
