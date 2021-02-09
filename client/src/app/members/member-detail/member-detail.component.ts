import { AbstractType, Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs/operators';
import { Member } from 'src/app/_models/member';
import { Message } from 'src/app/_models/message';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { MemberService } from 'src/app/_services/member.service';
import { MessageService } from 'src/app/_services/message.service';

@Component({
  selector: 'app-member-detail',
  templateUrl: './member-detail.component.html',
  styleUrls: ['./member-detail.component.scss']
})
export class MemberDetailComponent implements OnInit {
  @ViewChild('memberTabs', {static: true}) memberTabs: any;
  member: Member;
  messages: Message[] = [];
  activeTab: any;
  user: User;
  chatToggle: boolean = false;

  constructor(private memberService: MemberService, 
    private accountService: AccountService,
    private router: Router,
    private route: ActivatedRoute, 
    private toastr: ToastrService, 
    private messageService: MessageService) { 
      this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
      this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    }

  ngOnInit() {
    this.loadMember();
    // this.messageService.createHubConnection(this.user, this.member.userName);
    this.route.queryParams.subscribe(params => {
      params.tab ? this.selectTab(params.tab) : this.selectTab(0);
    })
  }

  loadMessages() {
    this.messageService.getMessageThread(this.member.userName).subscribe(messages => {
      this.messages = messages;
    })
  }

  showChat(data) {
    console.log(data);
    this.messageService.createHubConnection(this.user, this.member.userName);
    this.chatToggle = !this.chatToggle;
  }

  onTabActivated(data) {
    this.activeTab = data;
    if (this.messages.length === 0) {
      this.messageService.createHubConnection(this.user, this.member.userName);
    } else {
      this.messageService.stopHubConnection();
    }
  }

  loadMember() {
    this.memberService.getMember(this.route.snapshot.paramMap.get('username'))
      .subscribe(member => this.member = member);
  }

  addInvite(member: Member) {
    this.memberService.addInvite(member.userName).subscribe(() => {
    })
    this.toastr.success('You have invited ' + member.userName);
  }

  selectTab(tabId: number) {
    this.memberTabs.tabs[tabId].active = true;
  }

  ngOnDestroy(): void {
    this.messageService.stopHubConnection();
  }

}
