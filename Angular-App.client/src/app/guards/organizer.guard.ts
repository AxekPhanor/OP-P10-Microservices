import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthenticationService } from '../services/authentication.service';
import { catchError, map, of } from 'rxjs';

export const organizerGuard: CanActivateFn = (route, state) => {
  const authService = inject(AuthenticationService);
  const router = inject(Router);
  return authService.isConnected().pipe(
    map((value) => {
      return true;
    }),
    catchError((error) => {
      router.navigate(['login']);
      return of(false);
    })
  );
};
