import { Component } from '@angular/core';
import { GestionPatientsService } from '../../services/gestion-patients.service';

@Component({
  selector: 'app-page-gestion-patients',
  templateUrl: './page-gestion-patients.component.html',
  styleUrl: './page-gestion-patients.component.css'
})
export class PageGestionPatientsComponent {
  constructor(private gestionPatientsService: GestionPatientsService) { }

  ngOnInit() {
    this.getAll();
  }

  private getAll() {
    this.gestionPatientsService.GetAll().subscribe({
      next: (patients) => {
        console.log(patients);
      }
    })
  }
}
