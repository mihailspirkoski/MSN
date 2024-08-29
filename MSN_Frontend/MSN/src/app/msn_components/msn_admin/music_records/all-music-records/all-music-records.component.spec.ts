import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllMusicRecordsComponent } from './all-music-records.component';

describe('AllMusicRecordsComponent', () => {
  let component: AllMusicRecordsComponent;
  let fixture: ComponentFixture<AllMusicRecordsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AllMusicRecordsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AllMusicRecordsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
