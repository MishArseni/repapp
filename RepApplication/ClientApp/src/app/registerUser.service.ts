import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from './models/user';

@Injectable()
export class RegisterUserService {

  private url = "/api/registrateuser";

  constructor(private http: HttpClient) {
  }

  loginUser(user: User) {
    return this.http.put(this.url,user);
  }

  registerUser(user: User) {
    return this.http.post(this.url, user);
  }
}
