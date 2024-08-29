import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HiphopRecordsComponent } from './hiphop-records.component';

describe('HiphopRecordsComponent', () => {
  let component: HiphopRecordsComponent;
  let fixture: ComponentFixture<HiphopRecordsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [HiphopRecordsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HiphopRecordsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
