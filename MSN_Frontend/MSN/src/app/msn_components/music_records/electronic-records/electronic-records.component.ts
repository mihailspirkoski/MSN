import { Component, inject, OnInit } from '@angular/core';
import { IMusicRecord } from '../../../msn_interfaces/imusicrecord';
import { MusicRecordService } from '../../../msn_services/music_record/music-record.service';

@Component({
  selector: 'app-electronic-records',
  templateUrl: './electronic-records.component.html',
  styleUrl: './electronic-records.component.scss'
})
export class ElectronicRecordsComponent implements OnInit {

  allElectronicRecords: IMusicRecord[] = [];
  splitRecords: any;

  _musicRecordsService = inject(MusicRecordService);

  ngOnInit(): void {
    this._musicRecordsService.getAllElectronicRecords().subscribe({
      next: (data: any) => {
        this.allElectronicRecords = data;
        this.splitRecords = this.splitArr(this.allElectronicRecords, 3);
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
