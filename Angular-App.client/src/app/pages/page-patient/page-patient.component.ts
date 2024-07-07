import { Component, Input } from '@angular/core';
import { GestionPatientsService } from '../../services/gestion-patients.service';
import { ActivatedRoute, Router } from '@angular/router';
import { PatientOutput } from '../../models/patientOutput';

@Component({
  selector: 'app-page-patient',
  templateUrl: './page-patient.component.html',
  styleUrl: './page-patient.component.css'
})
export class PagePatientComponent {
  constructor(private gestionPatientsService: GestionPatientsService, private router: Router, private route: ActivatedRoute) { }

  @Input() patient: PatientOutput = {
    id: Number(this.route.snapshot.paramMap.get('id')),
    firstName: "",
    lastName: "",
    dateOfBirth: "",
    gender: "",
    address: "",
    phoneNumber: ""
  }

  ngOnInit() {
    this.getById();
  }

  private getById() {
    this.gestionPatientsService.get(this.patient.id).subscribe({
      next: value => {
        this.patient = value as PatientOutput;
        if (this.patient.address == "") {
          this.patient.address = "non renseigné"
        }
        if (this.patient.phoneNumber == "") {
          this.patient.phoneNumber = "non renseigné"
        }
      },
      error: err => {
        console.error("error getbyid ", err);
      }
    })
  }
}
