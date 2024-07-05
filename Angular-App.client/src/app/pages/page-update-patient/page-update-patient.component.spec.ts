import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PageUpdatePatientComponent } from './page-update-patient.component';

describe('PageUpdatePatientComponent', () => {
  let component: PageUpdatePatientComponent;
  let fixture: ComponentFixture<PageUpdatePatientComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PageUpdatePatientComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PageUpdatePatientComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
