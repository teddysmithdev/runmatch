import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from 'src/app/_services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  model: any = {};
  registerForm: FormGroup;
  maxDate: Date;
  validationErrors: string[];

  constructor(private accountService: AccountService, private router: Router, private toastr: ToastrService, private route: Router) { }

  ngOnInit() {
    this.initializeForm();
    this.maxDate = new Date();
    this.maxDate.setFullYear(this.maxDate.getFullYear() - 18)

  }

  initializeForm() {
    this.registerForm = new FormGroup({
      username: new FormControl(null,Validators.required),
      password: new FormControl(null, [Validators.required, Validators.minLength(4), Validators.maxLength(15)]),
      confirmPassword: new FormControl(null, [Validators.required, this.matchValues('password')])
    })
  }

  matchValues(matchTo: string): ValidatorFn {
    return (control: AbstractControl) => {
      return control?.value === control?.parent?.controls[matchTo].value ? null : {isMatching: true}
    }
  }


  register() {
    this.accountService.register(this.registerForm.value).subscribe(response => {
      this.router.navigateByUrl('onboard')
      this.toastr.success("You are registered!", "Success")
    }, error => {
      this.validationErrors = error;
      this.toastr.warning(error.error, "Error!")
    })
  }

}
