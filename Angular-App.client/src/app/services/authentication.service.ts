import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService extends BaseService {

  login(username: string, password: string): Observable<User> {
    return this.http.post<User>(`${this.url}/login`, {
      username: username,
      password: password
    },
    {
      withCredentials: true
    });
  }

  logout() {
    return this.http.get(`${this.url}/logout`, {
      withCredentials: true
    })
  }
}
