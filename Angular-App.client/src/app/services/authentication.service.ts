import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { Token } from '@angular/compiler';
import { HttpClient } from '@angular/common/http';
import { LocalStorageService } from './local-storage.service';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService extends BaseService {
  constructor(http: HttpClient, private localStorage: LocalStorageService) {
    super(http);
  }
  login(username: string, password: string): Observable<Token> {
    return this.http.post<Token>(`${this.url}/login`, {
      username: username,
      password: password
    },
    {
      withCredentials: true
    });
  }

  isConnected(): Observable<boolean> {
    return this.http.get<boolean>(`${this.url}/isconnected`, {
      headers: { 'Authorization': 'Bearer ' + this.localStorage.getItem('token') },
      withCredentials: true
    });
  }
}
