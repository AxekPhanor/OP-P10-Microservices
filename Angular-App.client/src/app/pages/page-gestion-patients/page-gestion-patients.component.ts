import { Component } from '@angular/core';
import { GestionPatientsService } from '../../services/gestion-patients.service';
import { PatientOutput } from '../../models/patientOutput';
import { Observable, of } from 'rxjs';

@Component({
  selector: 'app-page-gestion-patients',
  templateUrl: './page-gestion-patients.component.html',
  styleUrl: './page-gestion-patients.component.css'
})
export class PageGestionPatientsComponent {
  constructor(private gestionPatientsService: GestionPatientsService) { }
  patients: PatientOutput[] = [];
  displayedColumns: string[] = ['id', 'firstName', 'lastName', 'dateOfBirth', 'gender', 'address', 'phoneNumber', 'update', 'delete'];
  patientObservable: Observable<PatientOutput[]> = new Observable<PatientOutput[]>();
  ngOnInit() {
    this.getAll();
  }

  private getAll() {
    this.gestionPatientsService.GetAll().subscribe({
      next: value => {
        this.patients = value as PatientOutput[];
        this.patientObservable = of(this.patients.map(patient => patient));
      }
    })
  }
}
