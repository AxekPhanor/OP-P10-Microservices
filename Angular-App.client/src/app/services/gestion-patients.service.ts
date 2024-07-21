import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { PatientInput } from '../models/patientInput';
import { PatientOutput } from '../models/patientOutput';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GestionPatientsService extends BaseService {

  getAll(): Observable<Array<PatientOutput>> {
    return this.http.get<Array<PatientOutput>>(`${this.url}/patients`, {
      headers: { 'Authorization': 'Bearer ' + this.localStorage.getItem('token') },
      withCredentials: true
    });
  }

  create(patient: PatientInput): Observable<PatientOutput> {
    return this.http.post<PatientOutput>(`${this.url}/patient/create`, {
        FirstName: patient.firstName,
        LastName: patient.lastName,
        DateOfBirth: patient.dateOfBirth,
        Gender: patient.gender,
        Address: patient.address,
        PhoneNumber: patient.phoneNumber
    },
      {
        headers: { 'Authorization': 'Bearer ' + this.localStorage.getItem('token') },
        withCredentials: true
      });
  }

  update(patient: PatientInput, id: number): Observable<PatientOutput> {
    return this.http.put<PatientOutput>(`${this.url}/patient/update?id=${id}`, {
      FirstName: patient.firstName,
      LastName: patient.lastName,
      DateOfBirth: patient.dateOfBirth,
      Gender: patient.gender,
      Address: patient.address,
      PhoneNumber: patient.phoneNumber
    },
      {
        headers: { 'Authorization': 'Bearer ' + this.localStorage.getItem('token') },
        withCredentials: true
      });
  }

  get(id: number): Observable<PatientOutput> {
    return this.http.get<PatientOutput>(`${this.url}/patient/get?id=${id}`, {
      headers: { 'Authorization': 'Bearer ' + this.localStorage.getItem('token') },
      withCredentials: true
    });
  }

  delete(id: number): Observable<PatientOutput> {
    return this.http.delete<PatientOutput>(`${this.url}/patient/delete?id=${id}`, {
      headers: { 'Authorization': 'Bearer ' + this.localStorage.getItem('token') },
      withCredentials: true
    });
  }
}
