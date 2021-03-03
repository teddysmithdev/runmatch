import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminPanelComponent } from './admin/admin-panel/admin-panel.component';
import { LoginComponent } from './auth/login/login.component';
import { OnboardComponent } from './auth/onboard/onboard.component';
import { RegisterComponent } from './auth/register/register.component';
import { BlogEditComponent } from './blog/blog-edit/blog-edit.component';
import { ClubCreateComponent } from './clubs/club-create/club-create.component';
import { ClubDetailComponent } from './clubs/club-detail/club-detail.component';
import { ClubListStateComponent } from './clubs/club-list-state/club-list-state.component';
import { ClubListComponent } from './clubs/club-list/club-list.component';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { HomeComponent } from './home/home.component';
import { InvitesComponent } from './invites/invites.component';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { MemberEditComponent } from './members/member-edit/member-edit.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MessagesComponent } from './messages/messages.component';
import { AdminGuard } from './_guards/admin.guard';
import { AuthGuard } from './_guards/auth.guard';
import { PreventUnsavedChangesGuard } from './_guards/prevent-unsaved-changes.guard';
import { LocationResolver } from './_resolvers/location.resolver';

const routes: Routes = [
  { path: "", component: HomeComponent, resolve: {location: LocationResolver} },
  { path: "members", component: MemberListComponent, canActivate: [AuthGuard], data: {breadcrumb: 'Find other runners'} },
  { path: "members/:username", component: MemberDetailComponent, canActivate: [AuthGuard] },
  { path: "member/edit", component: MemberEditComponent, canActivate: [AuthGuard], canDeactivate: [PreventUnsavedChangesGuard] },
  { path: "onboard", component: OnboardComponent, canActivate: [AuthGuard] },
  { path: "invites", component: InvitesComponent, canActivate: [AuthGuard] },
  { path: "running-club", component: ClubListComponent, resolve: {location: LocationResolver}, pathMatch: 'full' },
  { path: "running-club/:id", component: ClubDetailComponent, data:{breadcrumb: {alias: "clubDetail"}} },
  { path: "running-clubs/:state", component: ClubListStateComponent, data:{breadcrumb: {alias: "clubDetail"}} },
  { path: "club-create", component: ClubCreateComponent, canActivate: [AuthGuard] },
  { path: "blog-dashboard", component: BlogEditComponent, canActivate: [AuthGuard] },
  { path: "messages", component: MessagesComponent, canActivate: [AuthGuard] },
  { path: "admin", component: AdminPanelComponent, canActivate: [AdminGuard] },
  { path: "login", component: LoginComponent },
  { path: "register", component: RegisterComponent },
  { path: "errors", component: TestErrorsComponent },
  { path: "server-error", component: ServerErrorComponent },
  { path: "**", component: NotFoundComponent, pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
