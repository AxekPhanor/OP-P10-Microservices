import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Note } from '../models/note';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GestionNotesService extends BaseService {

  create(note: Note): Observable<Note> {
    return this.http.post<Note>(`${this.url}/note/create`, {
      content: note.content,
      patientId: note.patientId
    },
      {
        headers: { 'Authorization': 'Bearer ' + this.localStorage.getItem('token') },
        withCredentials: true
      });
  }

  list(patientdId: number): Observable<Note[]> {
    return this.http.get<Note[]>(`${this.url}/notes?patientId=${patientdId}`, {
      headers: { 'Authorization': 'Bearer ' + this.localStorage.getItem('token') },
      withCredentials: true
    });
  }
}
