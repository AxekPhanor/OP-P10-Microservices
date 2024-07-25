import { Component, Input } from '@angular/core';
import { GestionPatientsService } from '../../services/gestion-patients.service';
import { ActivatedRoute, Router } from '@angular/router';
import { PatientOutput } from '../../models/patientOutput';
import { Note } from '../../models/note';
import { GestionNotesService } from '../../services/gestion-notes.service';
import { FormControl, FormGroup } from '@angular/forms';
import { DiabeteRiskService } from '../../services/diabete-risk.service';

@Component({
  selector: 'app-page-patient',
  templateUrl: './page-patient.component.html',
  styleUrl: './page-patient.component.css'
})
export class PagePatientComponent {
  constructor(
    private gestionPatientsService: GestionPatientsService,
    private gestionNoteService: GestionNotesService,
    private diabeteRiskService: DiabeteRiskService,
    private router: Router,
    private route: ActivatedRoute) { }

  @Input() patient: PatientOutput = {
    id: Number(this.route.snapshot.paramMap.get('id')),
    firstName: "",
    lastName: "",
    dateOfBirth: "",
    gender: "",
    address: "",
    phoneNumber: ""
  }

  @Input() notes: Note[] = []

  form = new FormGroup({
    controlContent: new FormControl('')
  });

  risk: string = "";

  onSubmit() {
    const note: Note = {
      id: null,
      content: this.form.value.controlContent!,
      patientId: this.patient.id
    }
    this.gestionNoteService.create(note).subscribe({
      next: value => {
        const result = value as Note;
        this.notes.unshift(result);
      },
      error: (err) => {
        console.error('create patient error', err);
      }
    });
  }

  ngOnInit() {
    this.getById();
    this.listNotes();
    this.getRisk(Number(this.route.snapshot.paramMap.get('id')));
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
        this.router.navigate(['/']);
      }
    });
  }

  private listNotes() {
    this.gestionNoteService.list(this.patient.id).subscribe({
      next: value => {
        this.notes = value as Note[];
      },
      error: err => {
        console.error("error list notes ", err);
      }
    });
  }

  private getRisk(id: number) {
    this.diabeteRiskService.get(id).subscribe({
      next: value => {
        switch (value) {
          case 0: {
            this.risk = "aucun risque";
            break;
          }
          case 1: {
            this.risk = "risque limité";
            break;
          }
          case 2: {
            this.risk = "danger";
            break;
          }
          case 3: {
            this.risk = "apparition précoce";
            break;
          }
        }
      }
    });
  }
}