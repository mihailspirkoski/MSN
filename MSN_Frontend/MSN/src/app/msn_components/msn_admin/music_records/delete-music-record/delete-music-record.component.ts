import { Component, inject } from '@angular/core';
import { IMusicRecord } from '../../../../msn_interfaces/imusicrecord';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthenticationService } from '../../../../msn_services/authentication/authentication.service';
import { ActivatedRoute, Router } from '@angular/router';
import { MusicRecordService } from '../../../../msn_services/music_record/music-record.service';

@Component({
  selector: 'app-delete-music-record',
  templateUrl: './delete-music-record.component.html',
  styleUrl: './delete-music-record.component.scss'
})
export class DeleteMusicRecordComponent {

  id: any;
  musicRecord!: IMusicRecord;
  isLoggedIn!: boolean;
  isAdmin!: boolean;
  _fb = inject(FormBuilder);
  _auth = inject(AuthenticationService);
  _router = inject(Router);
  _musicRecordService = inject(MusicRecordService);
  _route = inject(ActivatedRoute);
  deleteRecordForm!: FormGroup;


  ngOnInit(): void {

    this.isLoggedIn = this._auth.loggedIn();
    if (!this.isLoggedIn) {
      this._router.navigate(['login']);
    }
    this.isAdmin = this._auth.isAdmin();
    if (!this.isAdmin) {
      this._router.navigate(['access_denied']);
    }

    this.id = this._route.snapshot.paramMap.get("id");
    this._musicRecordService._url_singleMusicRecord = this._musicRecordService._url_singleMusicRecord + this.id;
    this._musicRecordService.getSingleMusicRecord().subscribe({
      next: (data: any) => {
        this.musicRecord = data;
        if (this.musicRecord === null) {
          this._router.navigate(['access_denied']);
        }
      },
      error: (err) => {
        console.log(err);
      }
    });

    this.deleteRecordForm = this._fb.group({
      id: ['', Validators.required],
      title: ['', Validators.required],
      artist: ['', Validators.required],
      genre: ['', Validators.required],
      type: ['', Validators.required],
      rating: ['', Validators.required],
      imageUrl: ['', Validators.required],
      url: ['', Validators.required]
    })
  }

  ngOnDestroy() {
    location.reload();
  }

  onSubmit() {
    return this._musicRecordService.deleteMusicRecord(this.deleteRecordForm.value).subscribe({
      next: (data: any) => {
        this._router.navigate(['all_music_records']);
      },
      error: (err) => {
        console.log(err);
        this._router.navigate(['all_music_records']);
      }
    });
  }

}
