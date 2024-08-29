import { AfterViewChecked, Component, ElementRef, inject, OnInit, ViewChild } from '@angular/core';
import { ChatService } from '../../../msn_services/chat/chat.service';
import { Router } from '@angular/router';
import { AuthenticationService } from '../../../msn_services/authentication/authentication.service';

@Component({
  selector: 'app-chat-room',
  templateUrl: './chat-room.component.html',
  styleUrl: './chat-room.component.scss'
})
export class ChatRoomComponent implements OnInit, AfterViewChecked {

  _chatService = inject(ChatService);
  _router = inject(Router);
  _authService = inject(AuthenticationService);
  messages: any[] = [];
  inputMessage: string = "";
  loggedInUserName!: string;
  roomName = sessionStorage.getItem("room");
  isLoggedIn!: boolean;
  @ViewChild('scrollMe') private scrollContainer!: ElementRef;

  ngOnInit(): void {
    this.isLoggedIn = this._authService.loggedIn()
    if (!this.isLoggedIn) {
      this._router.navigate(['login']);
    }
    this.loggedInUserName = this._authService.getFullnameAndAgeFromToken();
    this._chatService.messages$.subscribe(res => {
      this.messages = res;
    })
  }

  ngAfterViewChecked(): void {
    this.scrollContainer.nativeElement.scrollTop = this.scrollContainer.nativeElement.scrollHeight;
  }

  sendMessage() {
    this._chatService.sendMessage(this.inputMessage).then(() => {
      this.inputMessage = "";
    }).catch((err) => {
      console.log(err);
    });
  }

  leaveChat() {
    this._chatService.leaveChat().then(() => {
      this._router.navigate(['']);
      setTimeout(() => {
        location.reload();
      }, 0);
    }).catch((err) => {
      console.log(err);
    });
  }

}
