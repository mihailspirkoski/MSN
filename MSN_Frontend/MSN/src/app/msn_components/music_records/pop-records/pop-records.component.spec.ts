import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PopRecordsComponent } from './pop-records.component';

describe('PopRecordsComponent', () => {
  let component: PopRecordsComponent;
  let fixture: ComponentFixture<PopRecordsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PopRecordsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PopRecordsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
