import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { PatientInput } from '../models/patientInput';
import { PatientOutput } from '../models/patientOutput';
import { Observable } from 'rxjs';
import { LocalStorageService } from './local-storage.service';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class GestionPatientsService extends BaseService {
  constructor(http: HttpClient, private localStorage: LocalStorageService) {
    super(http);
  }

  GetAll(): Observable<Array<PatientOutput>> {
    return this.http.get<Array<PatientOutput>>(`${this.url}/patients`, {
      headers: { 'Authorization': 'Bearer ' + this.localStorage.getItem('token') },
      withCredentials: true
    });
  }

  Create(patient: PatientInput): Observable<PatientOutput> {
    return this.http.post<PatientOutput>(`${this.url}/create`, {
      patient: patient
    },
      {
        headers: { 'Authorization': 'Bearer ' + this.localStorage.getItem('token') },
        withCredentials: true
      });
  }

  Update(patient: PatientInput, id: number): Observable<PatientOutput> {
    return this.http.put<PatientOutput>(`${this.url}/update?id=${id}`, {
      patient: patient
    },
      {
        headers: { 'Authorization': 'Bearer ' + this.localStorage.getItem('token') },
        withCredentials: true
      });
  }

  Get(id: number): Observable<PatientOutput> {
    return this.http.get<PatientOutput>(`${this.url}/get?id=${id}`, {
      headers: { 'Authorization': 'Bearer ' + this.localStorage.getItem('token') },
      withCredentials: true
    });
  }

  Delete(id: number): Observable<PatientOutput> {
    return this.http.delete<PatientOutput>(`${this.url}/delete?id=${id}`, {
      headers: { 'Authorization': 'Bearer ' + this.localStorage.getItem('token') },
      withCredentials: true
    });
  }
}
