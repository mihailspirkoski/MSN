import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { jwtDecode } from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  _url_register: string = 'https://localhost:7203/api/Auth/register';
  _url_login: string = 'https://localhost:7203/api/Auth/login';

  _http = inject(HttpClient);

  register(userData: any) {
    return this._http.post<any>(this._url_register, userData);
  }

  login(userData: any) {
    return this._http.post<any>(this._url_login, userData);
  }

  logout() {
    return localStorage.removeItem('token');
  }

  loggedIn() {
    return !!localStorage.getItem('token');
  }

  getToken() {
    return localStorage.getItem('token');
  }

  getFullnameFromToken() {
    let token: any = this.getToken();
    let decoded: any = jwtDecode(token);
    let fullname = decoded['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'] + " " +
      decoded['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname'];
    return fullname;
  }

  getFullnameAndAgeFromToken() {
    let token: any = this.getToken();
    let decoded: any = jwtDecode(token);
    let fullname_age = decoded['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'] + " " +
      decoded['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname'] + "  age: " +
      decoded['http://schemas.microsoft.com/ws/2008/06/identity/claims/version'];
    return fullname_age;
  }

  isAdmin(): boolean {
    let token: any = this.getToken();
    let decoded: any = jwtDecode(token);
    let authCheck = decoded['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
    if (authCheck === 'Admin') {
      return true;
    } else {
      return false;
    }
  }

  isUser(): boolean {
    let token: any = this.getToken();
    let decoded: any = jwtDecode(token);
    let authCheck = decoded['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
    if (authCheck === 'StandardUser') {
      return true;
    } else {
      return false;
    }
  }
}
