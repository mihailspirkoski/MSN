import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MetalRecordsComponent } from './metal-records.component';

describe('MetalRecordsComponent', () => {
  let component: MetalRecordsComponent;
  let fixture: ComponentFixture<MetalRecordsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [MetalRecordsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MetalRecordsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
