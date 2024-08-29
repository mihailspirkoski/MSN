import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteMusicRecordComponent } from './delete-music-record.component';

describe('DeleteMusicRecordComponent', () => {
  let component: DeleteMusicRecordComponent;
  let fixture: ComponentFixture<DeleteMusicRecordComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DeleteMusicRecordComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeleteMusicRecordComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
