import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from 'src/app/_services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  model: any = {}
  loggedIn: boolean;

  constructor(private accountService: AccountService, private router: Router, private toastr: ToastrService) { }

  ngOnInit() {
  }

  login() {
    this.accountService.login(this.model).subscribe(response => {
        this.router.navigateByUrl('members')
        this.toastr.success('You are logged in!', 'Congratulations');
      }, error => {
        console.log(error);
      });
  }

}
