import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditMusicRecordComponent } from './edit-music-record.component';

describe('EditMusicRecordComponent', () => {
  let component: EditMusicRecordComponent;
  let fixture: ComponentFixture<EditMusicRecordComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [EditMusicRecordComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditMusicRecordComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
