import { TestBed } from '@angular/core/testing';

import { DiabeteRiskService } from './diabete-risk.service';

describe('DiabeteRiskService', () => {
  let service: DiabeteRiskService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DiabeteRiskService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
