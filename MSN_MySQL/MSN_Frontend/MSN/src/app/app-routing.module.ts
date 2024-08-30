import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AllForumPostsComponent } from './msn_components/forum_posts/all-forum-posts/all-forum-posts.component';
import { LoginComponent } from './msn_components/auth/login/login.component';
import { RegisterComponent } from './msn_components/auth/register/register.component';
import { LogoutComponent } from './msn_components/auth/logout/logout.component';
import { AppComponent } from './app.component';
import { RockRecordsComponent } from './msn_components/music_records/rock-records/rock-records.component';
import { PopRecordsComponent } from './msn_components/music_records/pop-records/pop-records.component';
import { HiphopRecordsComponent } from './msn_components/music_records/hiphop-records/hiphop-records.component';
import { ClassicalRecordsComponent } from './msn_components/music_records/classical-records/classical-records.component';
import { ElectronicRecordsComponent } from './msn_components/music_records/electronic-records/electronic-records.component';
import { MetalRecordsComponent } from './msn_components/music_records/metal-records/metal-records.component';
import { CreatePostComponent } from './msn_components/forum_posts/create-post/create-post.component';
import { JoinRoomComponent } from './msn_components/chat/join-room/join-room.component';
import { ChatRoomComponent } from './msn_components/chat/chat-room/chat-room.component';
import { HomeComponent } from './msn_components/home/home.component';
import { ErrorComponentComponent } from './msn_components/error-component/error-component.component';
import { CreateMusicRecordComponent } from './msn_components/msn_admin/music_records/create-music-record/create-music-record.component';
import { MsnAdminComponent } from './msn_components/msn_admin/msn-admin/msn-admin.component';
import { AllMusicRecordsComponent } from './msn_components/msn_admin/music_records/all-music-records/all-music-records.component';
import { EditMusicRecordComponent } from './msn_components/msn_admin/music_records/edit-music-record/edit-music-record.component';
import { DeleteMusicRecordComponent } from './msn_components/msn_admin/music_records/delete-music-record/delete-music-record.component';
import { ApprovePostComponent } from './msn_components/msn_admin/forum_posts/approve-post/approve-post.component';
import { AllUsersComponent } from './msn_components/msn_admin/users/all-users/all-users.component';
import { ChangePermissionsComponent } from './msn_components/msn_admin/users/change-permissions/change-permissions.component';
import { AllForumPostsTableComponent } from './msn_components/msn_admin/forum_posts/all-forum-posts-table/all-forum-posts-table.component';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'rock', component: RockRecordsComponent },
  { path: 'pop', component: PopRecordsComponent },
  { path: 'hiphop', component: HiphopRecordsComponent },
  { path: 'metal', component: MetalRecordsComponent },
  { path: 'classical', component: ClassicalRecordsComponent },
  { path: 'electronic', component: ElectronicRecordsComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'logout', component: LogoutComponent },
  { path: 'forum_posts', component: AllForumPostsComponent },
  { path: 'create_post', component: CreatePostComponent },
  { path: 'join-room', component: JoinRoomComponent },
  { path: 'chat', component: ChatRoomComponent },
  { path: 'msn_admin', component: MsnAdminComponent },
  { path: 'all_music_records', component: AllMusicRecordsComponent },
  { path: 'new_music_record', component: CreateMusicRecordComponent },
  { path: 'edit_music_record/:id', component: EditMusicRecordComponent },
  { path: 'delete_music_record/:id', component: DeleteMusicRecordComponent },
  { path: 'all_forum_posts', component: AllForumPostsTableComponent },
  { path: 'approve_forum_post/:id', component: ApprovePostComponent },
  { path: 'all_users', component: AllUsersComponent },
  { path: 'manage_users/:email', component: ChangePermissionsComponent },
  { path: "**", component: ErrorComponentComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
