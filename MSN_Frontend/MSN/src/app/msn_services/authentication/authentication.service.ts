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
    let token: any = this.getToken();
    let decoded: any = jwtDecode(token);
    let getExpired = decoded['exp'];
    let isExpired = (Math.floor((new Date).getTime() / 1000)) >= getExpired;
    if (isExpired) {
      localStorage.removeItem('token');
    }
    return !!localStorage.getItem('token');
  }

  getToken() {
    return localStorage.getItem('token');
  }

  getFullnameFromToken() {
    let token: any = this.getToken();
    let decoded: any = jwtDecode(token);
    let fullname = decoded['Firstname'] + " " +
      decoded['Lastname'];
    return fullname;
  }

  getFullnameAndAgeFromToken() {
    let token: any = this.getToken();
    let decoded: any = jwtDecode(token);
    let fullname_age = decoded['Firstname'] + " " +
      decoded['Lastname'] + "  age: " +
      decoded['Age'];
    return fullname_age;
  }

  getEmailFromToken() {
    let token: any = this.getToken();
    let decoded: any = jwtDecode(token);
    let email = decoded['Email'];
    return email;
  }

  isAdmin(): boolean {
    let token: any = this.getToken();
    let decoded: any = jwtDecode(token);
    let authCheck = decoded['Role'];
    if (authCheck === 'Admin') {
      return true;
    } else {
      return false;
    }
  }

  isUser(): boolean {
    let token: any = this.getToken();
    let decoded: any = jwtDecode(token);
    let authCheck = decoded['Role'];
    if (authCheck === 'StandardUser') {
      return true;
    } else {
      return false;
    }
  }
}
