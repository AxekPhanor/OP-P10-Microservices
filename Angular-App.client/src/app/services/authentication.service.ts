import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { SignInResult } from '../models/signInResult';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService extends BaseService {

  login(username: string, password: string): Observable<SignInResult> {
    return this.http.post<SignInResult>(`${this.url}/login`, {
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
