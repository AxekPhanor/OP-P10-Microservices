import { Component } from '@angular/core';
import { GestionPatientsService } from '../../services/gestion-patients.service';
import { FormControl, FormGroup } from '@angular/forms';
import { PatientInput } from '../../models/patientInput';
import { PatientOutput } from '../../models/patientOutput';
import { Router } from '@angular/router';

@Component({
  selector: 'app-page-create-patient',
  templateUrl: './page-create-patient.component.html',
  styleUrl: './page-create-patient.component.css'
})
export class PageCreatePatientComponent {
  constructor(private gestionPatientsService: GestionPatientsService, private router: Router) { }
  form = new FormGroup({
    controlFirstName: new FormControl(''),
    controlLastName: new FormControl(''),
    controlDateOfBirth: new FormControl(''),
    controlGender: new FormControl(''),
    controlAddress: new FormControl(''),
    controlPhoneNumber: new FormControl(''),
  });

  onSubmit() {
    const dateBirth = new Date(this.form.value.controlDateOfBirth!);
    dateBirth.setMinutes(dateBirth.getMinutes() - dateBirth.getTimezoneOffset());

    const patient: PatientInput = {
      firstName: this.form.value.controlFirstName!,
      lastName: this.form.value.controlLastName!,
      dateOfBirth: dateBirth.toISOString(),
      gender: this.form.value.controlGender!,
      address: null,
      phoneNumber: null
    }
    if (this.form.value.controlAddress != null) {
      patient.address = this.form.value.controlAddress;
    }
    if (this.form.value.controlPhoneNumber != null) {
      patient.phoneNumber = this.form.value.controlPhoneNumber;
    }
    this.gestionPatientsService.create(patient).subscribe({
      next: (value: PatientOutput) => {
        this.router.navigate(['/']);
      },
      error: (err) => {
        console.error('create patient error', err);
      }
    })
  }
}


