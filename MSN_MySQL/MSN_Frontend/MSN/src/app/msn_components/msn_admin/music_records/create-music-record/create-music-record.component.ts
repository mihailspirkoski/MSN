import { Component, ElementRef, inject, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MusicRecordService } from '../../../../msn_services/music_record/music-record.service';
import { AuthenticationService } from '../../../../msn_services/authentication/authentication.service';
import { data, error } from 'jquery';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-music-record',
  templateUrl: './create-music-record.component.html',
  styleUrl: './create-music-record.component.scss'
})
export class CreateMusicRecordComponent implements OnInit {

  createRecordForm!: FormGroup;
  isLoggedIn!: boolean;
  isAdmin!: boolean;
  @ViewChild("myinput") myInputField!: ElementRef;

  _fb = inject(FormBuilder);
  _musicRecordsService = inject(MusicRecordService);
  _auth = inject(AuthenticationService);
  _router = inject(Router);



  ngOnInit(): void {

    this.isLoggedIn = this._auth.loggedIn();
    if (!this.isLoggedIn) {
      this._router.navigate(['login']);
    }
    this.isAdmin = this._auth.isAdmin();
    if (!this.isAdmin) {
      this._router.navigate(['access_denied']);
    }

    this.createRecordForm = this._fb.group({
      title: ['', Validators.required],
      artist: ['', Validators.required],
      genre: ['', Validators.required],
      type: ['', Validators.required],
      rating: ['', Validators.required],
      imageUrl: ['', Validators.required],
      url: ['', Validators.required]
    })
  }

  ngAfterViewInit(): void {
    this.myInputField.nativeElement.focus();
  }

  onSubmit() {
    return this._musicRecordsService.createMusicRecord(this.createRecordForm.value).subscribe({
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



