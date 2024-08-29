import { inject, Injectable } from '@angular/core';
import { IMSNUser } from '../../msn_interfaces/iuser';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  _url_getAllUsers = 'https://localhost:7203/api/User/get-all-users';
  _url_getUser = 'https://localhost:7203/api/User/get-user/';
  _url_changePermission = 'https://localhost:7203/api/User/change-permissions';

  _http = inject(HttpClient);

  getAllUsers(): Observable<IMSNUser[]> {
    return this._http.get<IMSNUser[]>(this._url_getAllUsers);
  }

  getUser(): Observable<IMSNUser> {
    return this._http.get<IMSNUser>(this._url_getUser);
  }

  changePermission(newRole: any): Observable<any> {
    return this._http.post<any>(this._url_changePermission, newRole)
  }

  constructor() { }
}
