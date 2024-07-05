import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { GestionPatientsService } from '../../services/gestion-patients.service';
import { ActivatedRoute, Router } from '@angular/router';
import { PatientInput } from '../../models/patientInput';
import { PatientOutput } from '../../models/patientOutput';

@Component({
  selector: 'app-page-update-patient',
  templateUrl: './page-update-patient.component.html',
  styleUrl: './page-update-patient.component.css'
})
export class PageUpdatePatientComponent {
  constructor(private gestionPatientsService: GestionPatientsService, private router: Router, private route: ActivatedRoute) { }
  form = new FormGroup({
    controlFirstName: new FormControl(''),
    controlLastName: new FormControl(''),
    controlDateOfBirth: new FormControl(''),
    controlGender: new FormControl(''),
    controlAddress: new FormControl(''),
    controlPhoneNumber: new FormControl(''),
  });
  patient: PatientInput | undefined;
  id = Number(this.route.snapshot.paramMap.get('id'));

  ngOnInit() {
    this.getById();
  }

  onSubmit() {
    const patient: PatientInput = {
      firstName: this.form.value.controlFirstName!,
      lastName: this.form.value.controlLastName!,
      dateOfBirth: this.form.value.controlDateOfBirth!,
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
    this.gestionPatientsService.update(patient, this.id).subscribe({
      next: (value: PatientOutput) => {
        this.router.navigate(['/', 'patients']);
      },
      error: (err) => {
        console.error('create patient error', err);
      }
    })
  }

  private getById() {
    this.gestionPatientsService.get(this.id).subscribe({
      next: value => {
        this.patient = value as PatientInput;
        this.form.setValue({
          controlFirstName: this.patient?.firstName || '',
          controlLastName: this.patient?.lastName || '',
          controlDateOfBirth: this.patient?.dateOfBirth || '',
          controlGender: this.patient?.gender || '',
          controlAddress: this.patient?.address || '',
          controlPhoneNumber: this.patient?.phoneNumber || ''
        });
      },
      error: err => {
        console.error("error getbyid ", err);
      }
    })
  }
}
