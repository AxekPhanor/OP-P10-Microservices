import { Component } from '@angular/core';
import { AuthenticationService } from '../../services/authentication.service';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-page-login',
  templateUrl: './page-login.component.html',
  styleUrl: './page-login.component.css'
})
export class PageLoginComponent {
  form = new FormGroup({
    controlUsername: new FormControl(''),
    controlPassword: new FormControl(''),
  });
  constructor(private authService: AuthenticationService, private router: Router) {

  }

  ngOnInit() {
    this.authService.isConnected().subscribe({ next: (value) => { console.log(value) } });
  }

  onSubmit() {
    const username = this.form.value.controlUsername;
    const password = this.form.value.controlPassword;
    if (username != null && password != null) {
      this.authService.login(username, password).subscribe({
        next: (signInResult) => {
          if (signInResult.succeeded) {
            this.router.navigate(['/', 'patients']);
          }
        }
      })
    }
  }
}
