import { Component } from '@angular/core';
import { GestionPatientsService } from '../../services/gestion-patients.service';
import { PatientOutput } from '../../models/patientOutput';
import { Router } from '@angular/router';
import { MatTableDataSource } from '@angular/material/table';
import { AuthenticationService } from '../../services/authentication.service';

@Component({
  selector: 'app-page-gestion-patients',
  templateUrl: './page-gestion-patients.component.html',
  styleUrl: './page-gestion-patients.component.css'
})
export class PageGestionPatientsComponent {
  constructor(
    private gestionPatientsService: GestionPatientsService,
    private authenticationService: AuthenticationService,
    private router: Router) { }

  patients: PatientOutput[] = [];
  displayedColumns: string[] = ['firstName', 'lastName', 'dateOfBirth', 'gender', 'address', 'phoneNumber', 'details', 'update', 'delete'];
  dataSource = new MatTableDataSource<PatientOutput>(this.patients);

  ngOnInit() {
    this.getAll();
  }

  private getAll() {
    this.gestionPatientsService.getAll().subscribe({
      next: value => {
        this.patients = value as PatientOutput[];
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
        this.patients.splice(id - 1, 1);
        this.patients = [...this.patients];
      },
      error: err => {
        console.log("delete error " + err);
      }
    });
  }

  isOrganizer() {
    return this.authenticationService.isOrganizer();
  }

  isPractitioner() {
    return this.authenticationService.isPractitioner();
  }
}
