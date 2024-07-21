import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { Token } from '@angular/compiler';
import { jwtDecode } from 'jwt-decode';


@Injectable({
  providedIn: 'root'
})
export class AuthenticationService extends BaseService {

  login(username: string, password: string): Observable<Token> {
    return this.http.post<Token>(`${this.url}/login`, {
      username: username,
      password: password
    },
    {
      withCredentials: true
    });
  }

  isAuthenticated(): boolean {
    const token = localStorage.getItem('token');
    if (token == null) {
      return false;
    }
    return !this.jwtHelper.isTokenExpired(token);
  }


  isPractitioner(): boolean {
    const token = localStorage.getItem('token');

    if (token == null) {
      return false;
    }

    const tokenPayload = jwtDecode(token);
    const payload = tokenPayload as any;

    if (!payload.role.includes('practitioner')) {
      return false;
    }

    return true;
  }

  isOrganizer(): boolean {
    const token = localStorage.getItem('token');

    if (token == null) {
      return false;
    }

    const tokenPayload = jwtDecode(token);
    const payload = tokenPayload as any;

    if (!payload.role.includes('organizer')) {
      return false;
    }
    return true;
  }
}
