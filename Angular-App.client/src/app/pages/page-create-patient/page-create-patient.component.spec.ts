import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PageCreatePatientComponent } from './page-create-patient.component';

describe('PageCreatePatientComponent', () => {
  let component: PageCreatePatientComponent;
  let fixture: ComponentFixture<PageCreatePatientComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PageCreatePatientComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PageCreatePatientComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
