import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClassicalRecordsComponent } from './classical-records.component';

describe('ClassicalRecordsComponent', () => {
  let component: ClassicalRecordsComponent;
  let fixture: ComponentFixture<ClassicalRecordsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ClassicalRecordsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ClassicalRecordsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
