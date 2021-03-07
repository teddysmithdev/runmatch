import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FileUploadModule } from 'ng2-file-upload'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './nav/nav.component';
import { LoginComponent } from './auth/login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RegisterComponent } from './auth/register/register.component';
import { HomeComponent } from './home/home.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { SharedModule } from './_modules/shared.module';
import { ErrorInterceptor } from './_interceptors/error.interceptor';
import { JwtInterceptor } from './_interceptors/jwt.interceptor';
import { MemberEditComponent } from './members/member-edit/member-edit.component';
import { NgxSpinnerModule } from "ngx-spinner";
import { LoadingInterceptor } from './_interceptors/loading.interceptor';
import { PhotoEditorComponent } from './members/photo-editor/photo-editor.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { TextInputComponent } from './_forms/text-input/text-input.component';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { OnboardComponent } from './auth/onboard/onboard.component';
import { DateInputComponent } from './_forms/date-input/date-input.component';
import { InvitesComponent } from './invites/invites.component';
import { MessagesComponent } from './messages/messages.component';
import { AdminPanelComponent } from './admin/admin-panel/admin-panel.component';
import { HasRoleDirective } from './_directives/has-role.directive';
import { UserManagementComponent } from './admin/user-management/user-management.component';
import { PhotoManagementComponent } from './admin/photo-management/photo-management.component';
import { RolesModalComponent } from './modals/roles-modal/roles-modal.component';
import { MemberMessagesComponent } from './messages/member-messages/member-messages.component';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { ClubListComponent } from './clubs/club-list/club-list.component';
import { ClubDetailComponent } from './clubs/club-detail/club-detail.component';
import { ClubCreateComponent } from './clubs/club-create/club-create.component';
import { ToastrModule } from 'ngx-toastr';
import { AuthGuard } from './_guards/auth.guard';
import { FooterComponent } from './home/footer/footer.component';
import { BreadcrumbComponent } from './components/breadcrumb/breadcrumb.component';
import { BreadcrumbModule } from 'xng-breadcrumb';
import { SidebarStatesComponent } from './components/sidebar-states/sidebar-states.component';
import { ClubListStateComponent } from './clubs/club-list-state/club-list-state.component';
import { SlugifyPipe } from './_pipes/slugify.pipe';
import { LocationResolver } from './_resolvers/location.resolver';
import { DateTimePickerComponent } from './components/date-time-picker/date-time-picker.component';
import { NgbTimepicker, NgbTimepickerModule } from '@ng-bootstrap/ng-bootstrap';
import { SummaryPipe } from './_pipes/summary.pipe';
import { BlogsComponent } from './blog/blogs/blogs.component';
import { FamousBlogsComponent } from './blog/famous-blogs/famous-blogs.component';
import { BlogCommentComponent } from './blog/blog-comment/blog-comment.component';
import { CommentSystemComponent } from './blog/comment-system/comment-system.component';
import { CommentsComponent } from './blog/comments/comments.component';
import { BlogEditComponent } from './blog/blog-edit/blog-edit.component';
import { TypeaheadModule } from 'ngx-bootstrap/typeahead';
import { BlogDashboardComponent } from './blog/blog-dashboard/blog-dashboard.component';
import { BlogPhotosComponent } from './blog/blog-photos/blog-photos.component';
import { EventDetailComponent } from './events/event-detail/event-detail.component';
import { BlogComponent } from './blog/blog.component';
import { CommentBoxComponent } from './blog/comment-box/comment-box.component';


@NgModule({
  declarations: [				
    AppComponent,
      NavComponent,
      LoginComponent,
      RegisterComponent,
      HomeComponent,
      MemberListComponent,
      MemberEditComponent,
      MemberDetailComponent,
      PhotoEditorComponent,
      TextInputComponent,
      OnboardComponent,
      RegisterComponent,
      DateInputComponent,
      InvitesComponent,
      MessagesComponent,
      AdminPanelComponent,
      HasRoleDirective,
      UserManagementComponent,
      PhotoManagementComponent,
      RolesModalComponent,
      MemberMessagesComponent,
      ClubListComponent,
      ClubDetailComponent,
      ClubCreateComponent,
      FooterComponent,
      BreadcrumbComponent,
      SidebarStatesComponent,
      ClubListStateComponent,
      SlugifyPipe,
      DateTimePickerComponent,
      SummaryPipe,
      BlogsComponent,
      BlogComponent,
      BlogEditComponent,
      FamousBlogsComponent,
      BlogCommentComponent,
      CommentSystemComponent,
      CommentsComponent,
      BlogDashboardComponent,
      BlogPhotosComponent,
      EventDetailComponent,
      CommentBoxComponent
   ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    FormsModule,
    SharedModule,
    NgxSpinnerModule,
    FileUploadModule,
    FontAwesomeModule,
    BsDatepickerModule.forRoot(),
    NgbTimepickerModule,
    NgbTimepickerModule,
    BreadcrumbModule,
    TypeaheadModule
  ],
  providers: [
    LocationResolver,
    {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true},
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
