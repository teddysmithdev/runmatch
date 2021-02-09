import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Club } from 'src/app/_models/club';
import { Event } from 'src/app/_models/event';
import { ClubService } from 'src/app/_services/club.service';
import { EventService } from 'src/app/_services/event.service';

@Component({
  selector: 'app-club-detail',
  templateUrl: './club-detail.component.html',
  styleUrls: ['./club-detail.component.css']
})
export class ClubDetailComponent implements OnInit {

  club: Club;
  events: Event[];

  constructor(private clubService: ClubService, 
    private route: ActivatedRoute, 
    private toastr: ToastrService,
    private eventService: EventService) { }

  ngOnInit() {
    this.getClub();
    this.getEvents();
  }

  getClub() {
    this.clubService.getClub(this.route.snapshot.params['id']).subscribe((club: Club) => {
      this.club = club;
    }, error => {
      this.toastr.error(error);
    });
  }

  getEvents() {
    this.eventService.getEvents().subscribe((e:Event[]) => {
      this.events = e;
    }, error => {
      this.toastr.error(error);
  })
}

}
