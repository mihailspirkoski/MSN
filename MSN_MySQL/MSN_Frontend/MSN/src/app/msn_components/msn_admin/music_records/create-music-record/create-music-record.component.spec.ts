import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateMusicRecordComponent } from './create-music-record.component';

describe('CreateMusicRecordComponent', () => {
  let component: CreateMusicRecordComponent;
  let fixture: ComponentFixture<CreateMusicRecordComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CreateMusicRecordComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateMusicRecordComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
