import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthenticationService } from '../services/authentication.service';
import { jwtDecode } from 'jwt-decode';

export const practitionerGuard: CanActivateFn = (route, state) => {
  const authService = inject(AuthenticationService);
  const router = inject(Router);
  const token = localStorage.getItem('token');

  if (token == null) {
    return false;
  }

  const tokenPayload = jwtDecode(token);
  if (!authService.isAuthenticated()) {
    router.navigate(['login']);
    return false;
  }

  const payload = tokenPayload as any;
  if (payload.role != 'practitioner') {
    return false;
  }

  return true;
};
