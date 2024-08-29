import { Component, inject, OnInit } from '@angular/core';
import { IMusicRecord } from '../../../msn_interfaces/imusicrecord';
import { MusicRecordService } from '../../../msn_services/music_record/music-record.service';

@Component({
  selector: 'app-pop-records',
  templateUrl: './pop-records.component.html',
  styleUrl: './pop-records.component.scss'
})
export class PopRecordsComponent implements OnInit {

  allPopRecords: IMusicRecord[] = [];
  splitRecords: any;

  _musicRecordsService = inject(MusicRecordService);

  ngOnInit(): void {
    this._musicRecordsService.getAllPopRecords().subscribe({
      next: (data: any) => {
        this.allPopRecords = data;
        this.splitRecords = this.splitArr(this.allPopRecords, 3);
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
