import { Component, OnInit } from '@angular/core';
import { UserService } from '../user.service';
import { User } from '../models/user';

@Component({
  templateUrl: './user-list.component.html'
})

export class UserListComponent implements OnInit {

  users: User[];
  constructor(private userService: UserService) { }

  ngOnInit() {
    this.load();
  }
  load() {
    this.userService.getUsers().subscribe((data: User[]) => this.users = data);
  }

  delete(id: number) {
    this.userService.deleteUser(id).subscribe(data => this.load());
  }
}
