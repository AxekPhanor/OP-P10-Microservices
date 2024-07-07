import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { ReactiveFormsModule } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { HttpClientModule } from '@angular/common/http';
import { MatTableModule } from '@angular/material/table';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PageLoginComponent } from './pages/page-login/page-login.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { PageGestionPatientsComponent } from './pages/page-gestion-patients/page-gestion-patients.component';
import { PageCreatePatientComponent } from './pages/page-create-patient/page-create-patient.component';
import { PageUpdatePatientComponent } from './pages/page-update-patient/page-update-patient.component';
import { PagePatientComponent } from './pages/page-patient/page-patient.component';

@NgModule({
  declarations: [
    AppComponent,
    PageLoginComponent,
    PageGestionPatientsComponent,
    PageCreatePatientComponent,
    PageUpdatePatientComponent,
    PagePatientComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatInputModule,
    MatSelectModule,
    MatFormFieldModule,
    MatButtonModule,
    ReactiveFormsModule,
    MatIconModule,
    HttpClientModule,
    MatTableModule
  ],
  providers: [
    provideAnimationsAsync()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
