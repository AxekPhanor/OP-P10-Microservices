import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LocalStorageService } from './local-storage.service';
import { JwtHelperService } from '@auth0/angular-jwt';


@Injectable({
  providedIn: 'root'
})
export class BaseService {
  url: string;
  constructor(protected http: HttpClient, public localStorage: LocalStorageService, public jwtHelper: JwtHelperService) {
    this.url = 'http://localhost:5000/gateway';
  }
}
