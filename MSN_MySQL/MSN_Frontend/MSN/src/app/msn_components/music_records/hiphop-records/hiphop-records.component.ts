import { Component, inject, OnInit } from '@angular/core';
import { IMusicRecord } from '../../../msn_interfaces/imusicrecord';
import { MusicRecordService } from '../../../msn_services/music_record/music-record.service';

@Component({
  selector: 'app-hiphop-records',
  templateUrl: './hiphop-records.component.html',
  styleUrl: './hiphop-records.component.scss'
})
export class HiphopRecordsComponent implements OnInit {

  allHipHopRecords: IMusicRecord[] = [];
  splitRecords: any;

  _musicRecordsService = inject(MusicRecordService);

  ngOnInit(): void {
    this._musicRecordsService.getAllHipHopRecords().subscribe({
      next: (data: any) => {
        this.allHipHopRecords = data;
        this.splitRecords = this.splitArr(this.allHipHopRecords, 3);
      },
      error: (err) => {
        console.log(err);
      }
    });
  }

  splitArr(arr: any, size: number) {
    let newArr = [];
    for (let i = 0; i < arr.length; i += size) {
      newArr.push(arr.slice(i, i + size));
    }
    return newArr;
  }

}
