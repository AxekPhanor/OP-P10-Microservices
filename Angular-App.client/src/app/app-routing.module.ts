import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PageLoginComponent } from './pages/page-login/page-login.component';
import { PageGestionPatientsComponent } from './pages/page-gestion-patients/page-gestion-patients.component';
import { PageCreatePatientComponent } from './pages/page-create-patient/page-create-patient.component';
import { PageUpdatePatientComponent } from './pages/page-update-patient/page-update-patient.component';
import { organizerGuard } from './guards/organizer.guard';
import { PagePatientComponent } from './pages/page-patient/page-patient.component';

const routes: Routes = [
  { path: 'login', component: PageLoginComponent },
  { path: '', component: PageGestionPatientsComponent, canActivate: [organizerGuard] },
  { path: 'create', component: PageCreatePatientComponent, canActivate: [organizerGuard] },
  { path: 'update/:id', component: PageUpdatePatientComponent, canActivate: [organizerGuard] },
  { path: ':id', component: PagePatientComponent, canActivate: [organizerGuard] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
