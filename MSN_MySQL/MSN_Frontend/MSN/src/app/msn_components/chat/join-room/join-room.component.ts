import { AfterViewInit, Component, ElementRef, inject, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthenticationService } from '../../../msn_services/authentication/authentication.service';
import { Router } from '@angular/router';
import { ChatService } from '../../../msn_services/chat/chat.service';

@Component({
  selector: 'app-join-room',
  templateUrl: './join-room.component.html',
  styleUrl: './join-room.component.scss'
})
export class JoinRoomComponent implements OnInit, AfterViewInit {


  joinRoomForm!: FormGroup;

  _fb = inject(FormBuilder);
  _authService = inject(AuthenticationService);
  _router = inject(Router);
  _chatService = inject(ChatService);
  isLoggedIn!: boolean;
  @ViewChild("myinput") myInputField!: ElementRef;

  ngOnInit(): void {
    this.isLoggedIn = this._authService.loggedIn()
    if (!this.isLoggedIn) {
      this._router.navigate(['login']);
    }
    let fullname = this._authService.getFullnameAndAgeFromToken();
    this.joinRoomForm = this._fb.group({
      user: [`${fullname}`, Validators.required],
      room: ['Rock', Validators.required]
    })
  }
  ngAfterViewInit(): void {
    this.myInputField.nativeElement.focus();
  }

  joinRoom() {
    const { user, room } = this.joinRoomForm.value;
    sessionStorage.setItem("room", room);
    this._chatService.joinRoom(user, room)
      .then(() => {
        this._router.navigate(['chat']);
      }).catch((err) => {
        console.log(err);
      });
  }


}
