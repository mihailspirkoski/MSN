import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RockRecordsComponent } from './rock-records.component';

describe('RockRecordsComponent', () => {
  let component: RockRecordsComponent;
  let fixture: ComponentFixture<RockRecordsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [RockRecordsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RockRecordsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
