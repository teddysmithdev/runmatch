import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Club } from 'src/app/_models/club';
import { ClubParams } from 'src/app/_models/clubParams';
import { Pagination } from 'src/app/_models/pagination';
import { ClubService } from 'src/app/_services/club.service';

@Component({
  selector: 'app-club-list-state',
  templateUrl: './club-list-state.component.html',
  styleUrls: ['./club-list-state.component.css']
})
export class ClubListStateComponent implements OnInit {
  clubs: Club[];
  pagination: Pagination;
  clubParams: ClubParams = new ClubParams();

  constructor(private clubService: ClubService, 
    private toastr: ToastrService,
    private route: ActivatedRoute) { 
    
  }

  ngOnInit(): void {
    this.clubParams.state = this.route.snapshot.params['state']
    this.loadClubs();
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
