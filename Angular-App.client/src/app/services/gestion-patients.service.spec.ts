import { TestBed } from '@angular/core/testing';

import { GestionPatientsService } from './gestion-patients.service';

describe('GestionPatientsService', () => {
  let service: GestionPatientsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GestionPatientsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
