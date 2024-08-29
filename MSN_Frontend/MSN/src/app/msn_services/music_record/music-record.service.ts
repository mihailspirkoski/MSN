import { HttpClient, HttpHeaders } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { IMusicRecord } from '../../msn_interfaces/imusicrecord';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MusicRecordService {

  _url_getAllRockRecords = 'https://localhost:7203/api/MusicRecord/get-rock-records';
  _url_getAllPopRecords = 'https://localhost:7203/api/MusicRecord/get-pop-records';
  _url_getAllHipHopRecords = 'https://localhost:7203/api/MusicRecord/get-hiphop-records';
  _url_getAllClassicalRecords = 'https://localhost:7203/api/MusicRecord/get-classical-records';
  _url_getAllElectronicRecords = 'https://localhost:7203/api/MusicRecord/get-electronic-records';
  _url_getAllMetalRecords = 'https://localhost:7203/api/MusicRecord/get-metal-records';

  _url_allMusicRecords = 'https://localhost:7203/api/MusicRecord/get-all-records';
  _url_singleMusicRecord = 'https://localhost:7203/api/MusicRecord/get-single-record/';
  _url_createMusicRecord = 'https://localhost:7203/api/MusicRecord/create-record';
  _url_editMusicRecord = 'https://localhost:7203/api/MusicRecord/edit-record';
  _url_deleteMusicRecord = 'https://localhost:7203/api/MusicRecord/delete-record';

  _http = inject(HttpClient);


  getAllRockRecords(): Observable<IMusicRecord[]> {
    return this._http.get<IMusicRecord[]>(this._url_getAllRockRecords);
  }

  getAllPopRecords(): Observable<IMusicRecord[]> {
    return this._http.get<IMusicRecord[]>(this._url_getAllPopRecords);
  }

  getAllHipHopRecords(): Observable<IMusicRecord[]> {
    return this._http.get<IMusicRecord[]>(this._url_getAllHipHopRecords);
  }

  getAllClassicalRecords(): Observable<IMusicRecord[]> {
    return this._http.get<IMusicRecord[]>(this._url_getAllClassicalRecords);
  }

  getAllElectronicRecords(): Observable<IMusicRecord[]> {
    return this._http.get<IMusicRecord[]>(this._url_getAllElectronicRecords);
  }

  getAllMetalRecords(): Observable<IMusicRecord[]> {
    return this._http.get<IMusicRecord[]>(this._url_getAllMetalRecords);
  }

  getAllMusicRecords(): Observable<IMusicRecord[]> {
    return this._http.get<IMusicRecord[]>(this._url_allMusicRecords);
  }

  createMusicRecord(recordToAdd: any): Observable<IMusicRecord> {
    return this._http.post<any>(this._url_createMusicRecord, recordToAdd);
  }

  editMusicRecord(recordToEdit: IMusicRecord): Observable<IMusicRecord> {
    return this._http.post<IMusicRecord>(this._url_editMusicRecord, recordToEdit);
  }

  deleteMusicRecord(recordToDelete: IMusicRecord): Observable<IMusicRecord> {
    return this._http.post<IMusicRecord>(this._url_deleteMusicRecord, recordToDelete);
  }

  getSingleMusicRecord(): Observable<IMusicRecord> {
    return this._http.get<IMusicRecord>(this._url_singleMusicRecord);
  }

  constructor() { }
}
