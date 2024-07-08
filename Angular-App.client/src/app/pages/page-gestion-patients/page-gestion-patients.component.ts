import { Component } from '@angular/core';
import { GestionPatientsService } from '../../services/gestion-patients.service';
import { PatientOutput } from '../../models/patientOutput';
import { Observable, of } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-page-gestion-patients',
  templateUrl: './page-gestion-patients.component.html',
  styleUrl: './page-gestion-patients.component.css'
})
export class PageGestionPatientsComponent {
  constructor(private gestionPatientsService: GestionPatientsService, private router: Router) { }
  patients: PatientOutput[] = [];
  displayedColumns: string[] = ['id', 'firstName', 'lastName', 'dateOfBirth', 'gender', 'address', 'phoneNumber', 'details', 'update', 'delete'];
  patientObservable: Observable<PatientOutput[]> = new Observable<PatientOutput[]>();
  ngOnInit() {
    this.getAll();
  }

  private getAll() {
    this.gestionPatientsService.getAll().subscribe({
      next: value => {
        this.patients = value as PatientOutput[];
        this.patientObservable = of(this.patients.map(patient => patient));
      }
    });
  }

   navigateToCreate() {
     this.router.navigate(['create']);
  }

  navigateToUpdate(id: number) {
    this.router.navigate(['update', id]);
  }

  navigateToDetails(id: number) {
    this.router.navigate([id]);
  }

  delete(id: number) {
    this.gestionPatientsService.delete(id).subscribe({
      next: value => {
        this.patients.splice(id-1, 1);
        console.log("patient" + value.id + " delete");
      },
      error: err => {
        console.log("delete error " + err);
      }
    });
  }
}
