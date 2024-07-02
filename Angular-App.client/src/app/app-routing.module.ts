import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PageLoginComponent } from './pages/page-login/page-login.component';
import { PageGestionPatientsComponent } from './pages/page-gestion-patients/page-gestion-patients.component';

const routes: Routes = [
  { path: '', component: PageLoginComponent },
  { path: 'patients', component: PageGestionPatientsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
