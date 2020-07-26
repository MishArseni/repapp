import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '../models/user';
import { RegisterUserService } from '../registerUser.service';

@Component({
  templateUrl: './login.component.html'
})

export class LoginComponent {

  user: User = new User();
  constructor(private registerUserService: RegisterUserService, private router: Router) { }

  save() {
    this.registerUserService.loginUser(this.user).subscribe(data => this.router.navigateByUrl("/"));
  }

}
