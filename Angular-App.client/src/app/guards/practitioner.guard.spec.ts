import { TestBed } from '@angular/core/testing';
import { CanActivateFn } from '@angular/router';

import { practitionerGuard } from './practitioner.guard';

describe('practitionerGuard', () => {
  const executeGuard: CanActivateFn = (...guardParameters) => 
      TestBed.runInInjectionContext(() => practitionerGuard(...guardParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeGuard).toBeTruthy();
  });
});
