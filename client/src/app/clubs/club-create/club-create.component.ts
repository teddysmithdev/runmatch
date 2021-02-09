import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import Stepper from 'bs-stepper';
import { ToastrService } from 'ngx-toastr';
import { User } from 'src/app/_models/user';
import { ClubService } from 'src/app/_services/club.service';
import { environment } from 'src/environments/environment';


@Component({
  selector: 'app-club-create',
  templateUrl: './club-create.component.html',
  styleUrls: ['./club-create.component.css']
})
export class ClubCreateComponent implements OnInit {
  private stepper: Stepper;
  clubCreateForm: FormGroup;
  user: User;
  baseUrl = environment.apiUrl;

  constructor(
    private clubService: ClubService, 
    private toastr: ToastrService, 
    private router: Router,
    private fb: FormBuilder) { }

  ngOnInit(): void {
    this.stepper = new Stepper(document.querySelector("#stepper1"), {
      linear: false,
      animation: true,
    });
    this.initializeForm();
  }

  initializeForm() {
    this.clubCreateForm = this.fb.group({
      city: ['', Validators.required],
      state: ['', Validators.required],
      name: ['', Validators.required],
      intro: ['', Validators.required],
      events: this.fb.group({
        title: ['', Validators.required],
        location: ['', Validators.required],
        date: ['', Validators.required]
      })
    })
  }

  next() {
    this.stepper.next();
  }

  clubUpdate() {
    this.clubService.createClub(this.clubCreateForm.value).subscribe(
      (next) => {
        console.log(this.user);
        this.toastr.success('Club Created', 'Congratulations');
        this.router.navigate(["/members"]);
      },
      (error) => {
        console.log(error);
      }
    );
  }

}
