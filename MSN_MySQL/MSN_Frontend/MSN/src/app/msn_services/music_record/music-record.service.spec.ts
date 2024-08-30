import { TestBed } from '@angular/core/testing';

import { MusicRecordService } from './music-record.service';

describe('MusicRecordService', () => {
  let service: MusicRecordService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MusicRecordService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
