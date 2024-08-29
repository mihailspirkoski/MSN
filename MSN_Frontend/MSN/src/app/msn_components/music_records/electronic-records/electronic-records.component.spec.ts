import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ElectronicRecordsComponent } from './electronic-records.component';

describe('ElectronicRecordsComponent', () => {
  let component: ElectronicRecordsComponent;
  let fixture: ComponentFixture<ElectronicRecordsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ElectronicRecordsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ElectronicRecordsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
