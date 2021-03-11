import { Injectable } from '@angular/core';
import { RangeValueAccessor } from '@angular/forms';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { BehaviorSubject } from 'rxjs';
import { take } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { ClubComment } from '../_models/clubComment';
import { User } from '../_models/user';

@Injectable({
  providedIn: 'root'
})
export class ClubCommentService {
  hubUrl = environment.hubUrl;
  private hubConnection: HubConnection;
  private commentThreadSource = new BehaviorSubject<ClubComment[]>([]);
  commentThread$ = this.commentThreadSource.asObservable();

  constructor() { }


  createHubConnection(user: User, otherUsername: string) {
    this.hubConnection =  new HubConnectionBuilder()
    .withUrl(this.hubUrl + 'comment' + otherUsername, {
      accessTokenFactory: () => user.token
    })
    .withAutomaticReconnect()
    .build()
  
    this.hubConnection.start().catch(error => console.log(error))
  
    this.hubConnection.on("LoadComments", comments => {
      this.commentThreadSource.next(comments);
    });

    // this.hubConnection.on("RecieveComment", comment => {
    //   this.commentThread$.pipe(take(1)).subscribe(comments => {
    //     this.commentThreadSource.next([...comments, comment])
    //   })
    // })
  }

  async sendComment(username: string, content: string) {
    return this.hubConnection.invoke('SendComment', {recipientUsername: username, content}).catch(error => console.log(error));
  }

  stopHubConnection() {
    if (this.hubConnection) {
      this.hubConnection.stop();
    }
  }
}
