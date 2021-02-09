import { Component, Input, OnInit } from '@angular/core';
import { ModalDismissReasons, NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { EventEmitter } from 'events';
import { User } from 'src/app/_models/user';

@Component({
  selector: 'app-roles-modal',
  templateUrl: './roles-modal.component.html',
  styleUrls: ['./roles-modal.component.css'],
  providers: [NgbActiveModal]
})
export class RolesModalComponent implements OnInit {
  @Input() updateSelectedRoles = new EventEmitter();
  user: User;
  roles: any;
 

  constructor(public activeModal: NgbActiveModal) {}

  ngOnInit(): void {

  }

  updateRoles() {
    this.updateSelectedRoles.emit(this.roles);
    this.activeModal.dismiss();
  }




}
