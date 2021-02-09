import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Club } from 'src/app/_models/club';
import { ClubService } from 'src/app/_services/club.service';

@Component({
  selector: 'app-club-list',
  templateUrl: './club-list.component.html',
  styleUrls: ['./club-list.component.css']
})
export class ClubListComponent implements OnInit {

  clubs: Club[];

  constructor(private clubServce: ClubService, private toastr: ToastrService) { }

  ngOnInit() {
    this.loadClubs();
  }

  loadClubs() {
    this.clubServce.getClubs().subscribe((clubs: Club[]) => {
      this.clubs = clubs;
    }, error => {
      this.toastr.error(error);
    })
  }

}
