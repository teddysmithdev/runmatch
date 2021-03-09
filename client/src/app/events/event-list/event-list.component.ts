import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Eventt } from 'src/app/_models/eventt';
import { EventtParams } from 'src/app/_models/eventtParams';
import { PaginatedResult, Pagination } from 'src/app/_models/pagination';
import { EventService } from 'src/app/_services/event.service';

@Component({
  selector: 'app-event-list',
  templateUrl: './event-list.component.html',
  styleUrls: ['./event-list.component.css']
})
export class EventListComponent implements OnInit {
  events: PaginatedResult<Eventt[]>;
  eventParams: EventtParams = new EventtParams();
  pagination: Pagination;
  constructor(
    private eventService: EventService,
    private toastr: ToastrService,
  ) { }

  ngOnInit(): void {
    this.loadEvents();
  }

  loadEvents() {
    this.eventService.getEvents(this.eventParams).subscribe(response => {
      this.events = response;
    })
  }

  pageChanged(event: any) {
    this.eventParams.pageNumber = event.page;
    // this.memberService.setUserParams(this.userParams);
    this.loadEvents();
  }

}
