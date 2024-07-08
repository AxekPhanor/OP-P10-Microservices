import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { Token } from '@angular/compiler';
import { HttpClient } from '@angular/common/http';
import { LocalStorageService } from './local-storage.service';
import { JwtHelperService } from '@auth0/angular-jwt';


@Injectable({
  providedIn: 'root'
})
export class AuthenticationService extends BaseService {
  constructor(http: HttpClient, private localStorage: LocalStorageService, public jwtHelper: JwtHelperService) {
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

  isOrganizer(): Observable<boolean> {
    return this.http.get<boolean>(`${this.url}/isorganizer`, {
      headers: { 'Authorization': 'Bearer ' + this.localStorage.getItem('token') },
      withCredentials: true
    });
  }

  isPractitioner(): Observable<boolean> {
    return this.http.get<boolean>(`${this.url}/ispractitioner`, {
      headers: { 'Authorization': 'Bearer ' + this.localStorage.getItem('token') },
      withCredentials: true
    });
  }

  public isAuthenticated(): boolean {
    const token = localStorage.getItem('token');
    if (token == null) {
      return false;
    }
    return !this.jwtHelper.isTokenExpired(token);
  }
}
