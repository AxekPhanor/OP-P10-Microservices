import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { PatientInput } from '../models/patientInput';
import { PatientOutput } from '../models/patientOutput';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GestionPatientsService extends BaseService {
  GetAll(): Observable<Array<PatientOutput>> {
    return this.http.get<Array<PatientOutput>>(`${this.url}/patients`, {
      withCredentials: true
    });
  }

  Create(patient: PatientInput): Observable<PatientOutput> {
    return this.http.post<PatientOutput>(`${this.url}/create`, {
      patient: patient
    },
      {
        withCredentials: true
      });
  }

  Update(patient: PatientInput, id: number): Observable<PatientOutput> {
    return this.http.put<PatientOutput>(`${this.url}/update?id=${id}`, {
      patient: patient
    },
      {
        withCredentials: true
      });
  }

  Get(id: number): Observable<PatientOutput> {
    return this.http.get<PatientOutput>(`${this.url}/get?id=${id}`, {
      withCredentials: true
    });
  }

  Delete(id: number): Observable<PatientOutput> {
    return this.http.delete<PatientOutput>(`${this.url}/delete?id=${id}`, {
      withCredentials: true
    });
  }
}
