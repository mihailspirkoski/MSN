import { Component, inject, OnInit } from '@angular/core';
import { AuthenticationService } from '../../../../msn_services/authentication/authentication.service';
import { Router } from '@angular/router';
import { MusicRecordService } from '../../../../msn_services/music_record/music-record.service';
import { IMusicRecord } from '../../../../msn_interfaces/imusicrecord';


@Component({
  selector: 'app-all-music-records',
  templateUrl: './all-music-records.component.html',
  styleUrl: './all-music-records.component.scss'
})
export class AllMusicRecordsComponent implements OnInit {


  allMusicRecords: IMusicRecord[] = [];
  isLoggedIn!: boolean;
  isAdmin!: boolean;
  _auth = inject(AuthenticationService);
  _router = inject(Router);
  _musicRecordService = inject(MusicRecordService);


  ngOnInit(): void {

    this.isLoggedIn = this._auth.loggedIn();
    if (!this.isLoggedIn) {
      this._router.navigate(['login']);
    }
    this.isAdmin = this._auth.isAdmin();
    if (!this.isAdmin) {
      this._router.navigate(['access_denied']);
    }

    this._musicRecordService.getAllMusicRecords().subscribe({
      next: (data: any) => {
        this.allMusicRecords = data;
      },
      error: (err) => {
        console.log(err);
      }
    });

  }

}
