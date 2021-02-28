import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs/operators';
import { Club } from 'src/app/_models/club';
import { ClubParams } from 'src/app/_models/clubParams';
import { IpAddress } from 'src/app/_models/ipaddress';
import { Pagination } from 'src/app/_models/pagination';
import { User } from 'src/app/_models/user';
import { UserParams } from 'src/app/_models/userParams';
import { AccountService } from 'src/app/_services/account.service';
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
  clubParams: ClubParams = new ClubParams();
  user: User;

  constructor(
    private clubService: ClubService,
    private toastr: ToastrService,
    private accountService: AccountService,
    private activatedRoute: ActivatedRoute
    ) { 
    
    } 

  ngOnInit() {
    this.activatedRoute.data.subscribe((data) => {
      this.clubParams.city = data.location.city;
      this.clubParams.state = data.location.region;
    });
    this.loadClubs();
  }

  ngOnChanges() {
      
  }

  loadClubs() {
    this.clubService.getClubs(this.clubParams).subscribe(response => {
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
