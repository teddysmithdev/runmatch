import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Photo } from 'src/app/_models/photo';
import { PhotoService } from 'src/app/_services/photo.service';

@Component({
  selector: 'app-blog-photos',
  templateUrl: './blog-photos.component.html',
  styleUrls: ['./blog-photos.component.css']
})
export class BlogPhotosComponent implements OnInit {

  @ViewChild('photoForm') photoForm: NgForm;
  @ViewChild('photoUploadElement') photoUploadElement: ElementRef;

  photos: Photo[] = [];
  photoFile: any;
  newPhotoDescription: string;

  constructor(
    private photoService: PhotoService,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this.photoService.getPhotoById().subscribe(userPhotos => {
      this.photos = userPhotos;
    });
  }

  confirmDelete(photo: Photo) {
    photo.deleteConfirm = true;
  }

  cancelDeleteConfirm(photo: Photo) {
    photo.deleteConfirm = false;
  }

  deleteConfirmed(photo: Photo) {
    this.photoService.deletePhoto(photo.id).subscribe(() => {
      let index = 0;

      for (let i=0; i<this.photos.length; i++) {
        if (this.photos[i].id === photo.id) {
          index = i;
        }
      }

      if (index > -1) {
        this.photos.splice(index, 1);
      }

      this.toastr.info("Photo deleted.");
    });
  }

  onFileChange(event) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.photoFile = file;
    }
  }

  onSubmit() {

    const formData = new FormData();
    formData.append('file', this.photoFile, this.newPhotoDescription);

    this.photoService.create(formData).subscribe(createdPhoto => {
      
      this.photoForm.reset();
      this.photoUploadElement.nativeElement.value = '';

      this.toastr.info("Photo uploaded");
      this.photos.unshift(createdPhoto);

    });
  }

}
