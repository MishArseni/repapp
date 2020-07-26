import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '../models/user';
import { UserService } from '../user.service';

@Component({
  templateUrl: 'user-create.component.html'
})

export class UserCreateComponent {
  user: User = new User();
  constructor(private userService: UserService, private router: Router) { }

  save() {
    this.userService.createUser(this.user).subscribe(data => this.router.navigate(['/']));
    window.location.href = '/';
  }
}
