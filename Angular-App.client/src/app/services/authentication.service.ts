import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService extends BaseService {

  login(username: string, password: string): Observable<string> {
    return this.http.post<string>(`${this.url}/login`, {
      username: username,
      password: password
    },
    {
      withCredentials: true
    });
  }
}
