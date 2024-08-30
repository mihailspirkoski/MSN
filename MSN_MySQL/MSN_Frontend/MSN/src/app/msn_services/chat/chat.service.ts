import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ChatService {

  public connection: signalR.HubConnection = new signalR.HubConnectionBuilder().withUrl("https://localhost:7203/chat")
    .configureLogging(signalR.LogLevel.Information).build();

  public messages$ = new BehaviorSubject<any>([]);
  public connectedUsers$ = new BehaviorSubject<any>([]);
  public messages: any[] = [];
  public users: any[] = [];

  constructor() {
    this.start();
    this.connection.on("ReceiveMessage", (user: string, message: string, messageTime: string) => {
      this.messages = [...this.messages, { user, message, messageTime }];
      this.messages$.next(this.messages);
    });
    this.connection.on("ConnectedUser", (users: any) => {
      this.connectedUsers$.next(users);
    });
  }

  //start connection
  public async start() {
    try {
      await this.connection.start();
    } catch (error) {
      console.log(error);
    }
  }

  //join room
  public async joinRoom(user: string, room: string) {
    return this.connection.invoke("JoinRoom", { user, room });
  }


  //send messages
  public async sendMessage(message: string) {
    return this.connection.invoke("SendMessage", message);
  }


  //leave chat
  public async leaveChat() {
    return this.connection.stop();
  }
}
