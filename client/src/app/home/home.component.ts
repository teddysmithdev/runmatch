import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Club } from '../_models/club';
import { ClubParams } from '../_models/clubParams';
import { PaginatedResult } from '../_models/pagination';
import { AccountService } from '../_services/account.service';
import { ClubService } from '../_services/club.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  registerForm: FormGroup;
  registerMode = false;
  clubParams: ClubParams;
  clubs: Club[];
  validationErrors: string[] = [];
  pageNumber = 1;
  pageSize = 5;

  constructor(
    private accountService: AccountService, 
    private router: Router, 
    private toastr: ToastrService,
    private clubService: ClubService) { }

  ngOnInit() {
    this.initializeForm();
    this.getClubs();
  }

  initializeForm() {
    this.registerForm = new FormGroup({
      username: new FormControl('',Validators.required),
      password: new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(15)]),
      confirmPassword: new FormControl('', [Validators.required, this.matchValues('password')])
    })
  }

  matchValues(matchTo: string): ValidatorFn {
    return (control: AbstractControl) => {
      return control?.value === control?.parent?.controls[matchTo].value ? null : {isMatching: true}
    }
  }


  register() {
    this.accountService.register(this.registerForm.value).subscribe(response => {
      this.router.navigateByUrl('/onboard');
      this.toastr.success("Success, You are registered!")
    }, error => {
      console.log(error.error)
      this.validationErrors = error.error;
    })
  }

  getClubs() {
    this.clubService.getClubs(this.clubParams).subscribe(e => {
      this.clubs = e.result
    }, error => {
      this.toastr.error(error);
    })
  }



}
