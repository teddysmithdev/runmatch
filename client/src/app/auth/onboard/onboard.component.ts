import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { FileUploader } from 'ng2-file-upload';
import { Photo } from 'src/app/_models/photo';
import { User } from 'src/app/_models/user';
import { environment } from 'src/environments/environment';
import { BsDatepickerConfig } from "ngx-bootstrap/datepicker";
import Stepper from "bs-stepper";
import { AccountService } from 'src/app/_services/account.service';
import { MemberService } from 'src/app/_services/member.service';
import { take } from 'rxjs/operators';
import { Member } from 'src/app/_models/member';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-onboard',
  templateUrl: './onboard.component.html',
  styleUrls: ['./onboard.component.scss'],
  exportAs: 'editForm'
})
export class OnboardComponent implements OnInit {
  private stepper: Stepper;
  uploader: FileUploader;
  onBoardForm: FormGroup;
  user: User;
  member: Member;
  currentMain: Photo;
  baseUrl = environment.apiUrl;
  bsConfig: Partial<BsDatepickerConfig>;
  response: string;
  validationErrors: string[] = [];

  constructor(
    private accountService: AccountService, 
    private memberService: MemberService, 
    private toastr: ToastrService, 
    private router: Router,
    private fb: FormBuilder
    ) { 
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
  }

  ngOnInit() {
    this.stepper = new Stepper(document.querySelector("#stepper1"), {
      linear: false,
      animation: true,
    });
    this.initializeUploader();
    this.bsConfig = {
      containerClass: "theme-blue",
    };
    this.initializeForm();
  }

  initializeForm() {
    this.onBoardForm = this.fb.group({
      city: ['', Validators.required],
      state: ['', Validators.required],
      dateOfBirth: ['', Validators.required],
      gender: ['male'],
      pace: ['8', Validators.required],
      mileage: ['3', Validators.required],
      runtime: ['Morning', Validators.required]
    })
  }

  next() {
    this.stepper.next();
  }

  initializeUploader() {
    this.uploader = new FileUploader({
      url: this.baseUrl + '/api/user/add-photo',
      authToken: 'Bearer ' + this.user.token,
      isHTML5: true,
      allowedFileType: ['image'],
      removeAfterUpload: true,
      autoUpload: false,
      maxFileSize: 10 * 1024 * 1024

    });

    this.response = '';


    this.uploader.onAfterAddingFile = (file) => {
      file.withCredentials = false;
    };

    this.uploader.onSuccessItem = (item, response, status, headers) => {
      if (response) {
        const photo: Photo = JSON.parse(response);
        this.member.photos.push(photo);
        this.setMainPhoto(photo);
         if (photo.isMain) {
           this.user.photoUrl = photo.url;
           this.member.photoUrl = photo.url;
           this.accountService.setCurrentUser(this.user);
         }
      }
    }
    this.uploader.response.subscribe(res => this.response = "Photo uploaded. Success!");
    
  }

  deletePhoto(photoId: number) {
    this.memberService.deletePhoto(photoId).subscribe(() => {
      this.member.photos = this.member.photos.filter(x => x.id !== photoId)
    })
  }

  onBoardUpdate() {
    this.accountService.onboardUser(this.onBoardForm.value).subscribe(
      (next) => {
        console.log(this.user);
        this.toastr.success('Onboard complete', 'Congratulations');
        this.router.navigate(["/members"]);
      },
      (error) => {
        this.validationErrors = error;
        this.toastr.error('Error')
      }
    );
  }

  setMainPhoto(photo: Photo) {
    this.memberService.setMainPhoto(photo.id).subscribe(() => {
      this.user.photoUrl = photo.url;
      this.accountService.setCurrentUser(this.user);
      this.member.photoUrl = photo.url;
      this.member.photos.forEach(p => {
        if (p.isMain) p.isMain = false;
        if (p.id === photo.id) p.isMain = true;
      })
    })
  }


}
