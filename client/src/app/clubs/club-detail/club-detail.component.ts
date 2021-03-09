import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Title } from '@angular/platform-browser'
import { ToastrService } from 'ngx-toastr';
import { Club } from 'src/app/_models/club';
import { ClubService } from 'src/app/_services/club.service';
import { EventService } from 'src/app/_services/event.service';
import { BreadcrumbService } from 'xng-breadcrumb';
import { EventtParams } from 'src/app/_models/eventtParams';
import { PaginatedResult } from 'src/app/_models/pagination';
import { Eventt } from 'src/app/_models/eventt';

@Component({
  selector: 'app-club-detail',
  templateUrl: './club-detail.component.html',
  styleUrls: ['./club-detail.component.css']
})
export class ClubDetailComponent implements OnInit {
  eventtParams: EventtParams = new EventtParams();
  club: Club;
  events: PaginatedResult<Eventt[]>;

  constructor(private clubService: ClubService, 
    private route: ActivatedRoute, 
    private toastr: ToastrService,
    private eventService: EventService,
    private bcService: BreadcrumbService) { }

  ngOnInit() {
    this.getClub();
    this.getEvents();
  }

  getClub() {
    this.clubService.getClub(this.route.snapshot.queryParamMap.get('id')).subscribe((club: Club) => {
      this.club = club;
      this.bcService.set("@clubDetails", club.name)
    }, error => {
      this.toastr.error(error);
    });
  }

  getEvents() {
    this.eventService.getEvents(this.eventtParams).subscribe(e => {
      this.events = e;
    }, error => {
      this.toastr.error(error);
  })
}

}
