import { Component, OnInit } from '@angular/core';
import { take } from 'rxjs/operators';
import { Message } from '../_models/message';
import { Pagination } from '../_models/pagination';
import { User } from '../_models/user';
import { UserParams } from '../_models/userParams';
import { AccountService } from '../_services/account.service';
import { MessageService } from '../_services/message.service';

@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.css']
})
export class MessagesComponent implements OnInit {
  messages: Message[] = [];
  messageThread: Message[];
  pagination: Pagination;
  container = "Inbox";
  pageNumber = 1;
  pageSize = 5;
  user: User;
  userParams: UserParams;
  messageContent: string;

  constructor(private messageService: MessageService, private accountService: AccountService) { 
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => {
      this.user = user;
      this.userParams = new UserParams(user);
    })
  }

  ngOnInit() {
    this.loadMessages();
  }

  loadMessages() {
    this.messageService.getMessages(this.pageNumber, this.pageSize, this.container).subscribe(response => {
      this.messages = response.result;
      this.pagination = response.pagination;
    })
  }

  pageChanged(event: any) {
    this.pageNumber = event.page;
    this.loadMessages();
  }

  getMessageThread(user: any) {
    this.messageService.getMessageThread(user).subscribe(messageThread => {
      this.messageThread = messageThread;
    })
  }

  sendMessage(user) {
    this.messageService.sendMessage(user, this.messageContent).then(() => {

    })
  }
}
