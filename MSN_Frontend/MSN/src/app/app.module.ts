import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, withInterceptors } from '@angular/common/http';
import { DataTablesModule } from 'angular-datatables';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './msn_components/auth/login/login.component';
import { RegisterComponent } from './msn_components/auth/register/register.component';
import { provideHttpClient } from '@angular/common/http';
import { LogoutComponent } from './msn_components/auth/logout/logout.component';
import { tokenInterceptorInterceptor } from './msn_services/token-interceptor.interceptor';
import { AllForumPostsComponent } from './msn_components/forum_posts/all-forum-posts/all-forum-posts.component';
import { CreatePostComponent } from './msn_components/forum_posts/create-post/create-post.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RockRecordsComponent } from './msn_components/music_records/rock-records/rock-records.component';
import { PopRecordsComponent } from './msn_components/music_records/pop-records/pop-records.component';
import { HiphopRecordsComponent } from './msn_components/music_records/hiphop-records/hiphop-records.component';
import { ClassicalRecordsComponent } from './msn_components/music_records/classical-records/classical-records.component';
import { ElectronicRecordsComponent } from './msn_components/music_records/electronic-records/electronic-records.component';
import { MetalRecordsComponent } from './msn_components/music_records/metal-records/metal-records.component';
import { JoinRoomComponent } from './msn_components/chat/join-room/join-room.component';
import { ChatRoomComponent } from './msn_components/chat/chat-room/chat-room.component';
import { HomeComponent } from './msn_components/home/home.component';
import { HeaderComponentComponent } from './msn_components/header-component/header-component.component';
import { ErrorComponentComponent } from './msn_components/error-component/error-component.component';
import { CreateMusicRecordComponent } from './msn_components/msn_admin/music_records/create-music-record/create-music-record.component';
import { EditMusicRecordComponent } from './msn_components/msn_admin/music_records/edit-music-record/edit-music-record.component';
import { DeleteMusicRecordComponent } from './msn_components/msn_admin/music_records/delete-music-record/delete-music-record.component';
import { ApprovePostComponent } from './msn_components/msn_admin/forum_posts/approve-post/approve-post.component';
import { AllUsersComponent } from './msn_components/msn_admin/users/all-users/all-users.component';
import { ChangePermissionsComponent } from './msn_components/msn_admin/users/change-permissions/change-permissions.component';
import { MsnAdminComponent } from './msn_components/msn_admin/msn-admin/msn-admin.component';
import { AllMusicRecordsComponent } from './msn_components/msn_admin/music_records/all-music-records/all-music-records.component';
import { AllForumPostsTableComponent } from './msn_components/msn_admin/forum_posts/all-forum-posts-table/all-forum-posts-table.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    LogoutComponent,
    AllForumPostsComponent,
    CreatePostComponent,
    RockRecordsComponent,
    PopRecordsComponent,
    HiphopRecordsComponent,
    ClassicalRecordsComponent,
    ElectronicRecordsComponent,
    MetalRecordsComponent,
    JoinRoomComponent,
    ChatRoomComponent,
    HomeComponent,
    HeaderComponentComponent,
    ErrorComponentComponent,
    CreateMusicRecordComponent,
    EditMusicRecordComponent,
    DeleteMusicRecordComponent,
    ApprovePostComponent,
    AllUsersComponent,
    ChangePermissionsComponent,
    MsnAdminComponent,
    AllMusicRecordsComponent,
    AllForumPostsTableComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    NgbModule,
    DataTablesModule,
  ],
  providers:
    [
      provideHttpClient(withInterceptors([tokenInterceptorInterceptor])),
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
