import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PageGestionPatientsComponent } from './page-gestion-patients.component';

describe('PageGestionPatientsComponent', () => {
  let component: PageGestionPatientsComponent;
  let fixture: ComponentFixture<PageGestionPatientsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PageGestionPatientsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PageGestionPatientsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
