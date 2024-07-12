import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LocalStorageService } from './local-storage.service';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DiabeteRiskService extends BaseService {

  constructor(http: HttpClient, private localStorage: LocalStorageService) {
    super(http);
  }

  get(patientdId: number): Observable<number> {
    return this.http.get<number>(`${this.url}/diabeterisk/get?id=${patientdId}`, {
      headers: { 'Authorization': 'Bearer ' + this.localStorage.getItem('token') },
      withCredentials: true
    });
  }
}
