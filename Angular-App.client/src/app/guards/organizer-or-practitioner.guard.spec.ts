import { TestBed } from '@angular/core/testing';
import { CanActivateFn } from '@angular/router';

import { organizerOrPractitionerGuard } from './organizer-or-practitioner.guard';

describe('organizerOrPractitionerGuard', () => {
  const executeGuard: CanActivateFn = (...guardParameters) => 
      TestBed.runInInjectionContext(() => organizerOrPractitionerGuard(...guardParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeGuard).toBeTruthy();
  });
});
