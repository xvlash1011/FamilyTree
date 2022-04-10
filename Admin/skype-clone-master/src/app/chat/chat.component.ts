import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { AppService } from '../app.service';
import { ChatSignalrClient } from '../core/chat.signalr';
import { FriendDataService } from '../core/friend-data.service';
import { MessageDataService } from '../core/message-data.service';
import { RoomDataService } from '../core/room-data.service';
import { UserDataService } from '../core/user-data.service';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss'],
})
export class ChatComponent implements OnInit {
  isCreateRoomModalShow = false;
  isNewFriendModalShow = false;
  leftNavIndex = 0;
  currentUser: any = {
    id: 0,
    name: '',
  };

  newFriendId: string = '';
  newRoomName: string = '';
  newRoomMembers: any[] = [];
  selectedRoom: any = null;

  friends: any[] = [];
  rooms: any[] = [];
  messages: any[] = [];

  newMessage: string = '';

  chatHub?: ChatSignalrClient;

  constructor(
    private appService: AppService,
    private router: Router,
    private friendService: FriendDataService,
    private userService: UserDataService,
    private roomService: RoomDataService,
    private messageService: MessageDataService
  ) {}

  ngOnInit(): void {
    if (this.appService.currentUser == null) {
      this.router.navigateByUrl('/login');
      return;
    }

    this.currentUser = this.appService.currentUser;
    this.refreshFriendList();
    this.refreshRooms();

    this.chatHub = new ChatSignalrClient(`${environment.apiUrl}hubs/chat`);
    this.chatHub.messageReceived = (data) => {
      if (data.roomId == this.selectedRoom.id) {
        this.messageService.get(data.id).subscribe((message) => {
          this.appendMessage(message);
        });
      }
    };

    this.chatHub.start().then(() => {
      console.log('Connected to chathub');
    });
  }

  sendMessage() {
    this.messageService
      .add({
        roomId: this.selectedRoom.id,
        userId: this.currentUser.id,
        content: this.newMessage,
      })
      .subscribe((data) => {
        this.newMessage = '';
        this.chatHub?.send(data);
      });
  }

  appendMessage(message: any) {
    this.messages.push(message);
  }

  refreshRooms() {
    this.rooms = [];
    this.roomService
      .getParticipatedIn(this.currentUser.id)
      .subscribe(async (rawData) => {
        for (let item of rawData) {
          const room = await this.roomService.get(item.roomId).toPromise();
          this.rooms.push(room);
        }
      });
  }

  selectRoom(room: any) {
    this.selectedRoom = room;

    this.messageService.getByRoom(room.id).subscribe((data) => {
      this.messages = data;
    });
  }

  refreshFriendList() {
    this.friends = [];
    this.newRoomMembers = [];
    this.friendService
      .getAllOf(this.currentUser.id)
      .subscribe(async (rawData) => {
        for (let item of rawData) {
          const user = await this.userService.get(item.rightId).toPromise();
          this.friends.push(user);
          this.newRoomMembers.push({
            id: user.id,
            name: user.name,
            selected: false,
          });
        }
      });
  }

  createNewRoom() {
    this.isCreateRoomModalShow = !this.isCreateRoomModalShow;
  }

  addFriend() {
    this.friendService
      .add(this.currentUser.id, +this.newFriendId)
      .subscribe((data) => {
        this.refreshFriendList();
        this.isNewFriendModalShow = false;
        this.newFriendId = '';
      });
  }

  addRoom() {
    const data = {
      name: this.newRoomName,
      members: this.newRoomMembers
        .filter((e) => e.selected)
        .map((e) => {
          return {
            userId: e.id,
            role: 1,
          };
        }),
    };
    data.members.push({
      userId: this.currentUser.id,
      role: 0,
    });

    this.roomService.add(data).subscribe((data) => {
      this.isCreateRoomModalShow = false;
      this.newRoomName = '';
      this.refreshRooms();
    });
  }
}
