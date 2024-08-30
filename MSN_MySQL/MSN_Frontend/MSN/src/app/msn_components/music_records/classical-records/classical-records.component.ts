import { Component, OnInit, inject } from '@angular/core';
import { IMusicRecord } from '../../../msn_interfaces/imusicrecord';
import { MusicRecordService } from '../../../msn_services/music_record/music-record.service';

@Component({
  selector: 'app-classical-records',
  templateUrl: './classical-records.component.html',
  styleUrl: './classical-records.component.scss'
})
export class ClassicalRecordsComponent implements OnInit {

  allClassicalRecords: IMusicRecord[] = [];
  splitRecords: any;

  _musicRecordsService = inject(MusicRecordService);

  ngOnInit(): void {
    this._musicRecordsService.getAllClassicalRecords().subscribe({
      next: (data: any) => {
        this.allClassicalRecords = data;
        this.splitRecords = this.splitArr(this.allClassicalRecords, 3);
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
