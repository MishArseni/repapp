import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from './models/user';

@Injectable()
export class CurrentUserService {
  private url = "/api/getCurrentUser";

  constructor(private http: HttpClient) {
  }

  getCurrent() {
    return this.http.get(this.url);
  }

  deleteCurrent(user: User) {
    return this.http.post(this.url, user);
  }

}
