import { Component } from '@angular/core';
import { AuthenticationService } from '../../services/authentication.service';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { LocalStorageService } from '../../services/local-storage.service';

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
  constructor(private authService: AuthenticationService,
    private localStorageService: LocalStorageService,
    private router: Router) {
  }

  ngOnInit() {
    this.isConnected();
  }

  onSubmit() {
    const username = this.form.value.controlUsername;
    const password = this.form.value.controlPassword;
    if (username != null && password != null) {
      this.authService.login(username, password).subscribe({
        next: (token: any) => {
          this.localStorageService.setItem("token", token.value);
          this.router.navigate(['/']);
        },
        error: (err) => {
          console.error('Login error', err);
        }
      });
    }
  }

  private isConnected() {
    this.authService.isConnected().subscribe({
      next: value => {
        this.router.navigate(['/']);
      }
    })
  }
}
