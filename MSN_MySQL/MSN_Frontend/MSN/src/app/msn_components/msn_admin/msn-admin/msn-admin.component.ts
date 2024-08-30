import { Component, inject, OnInit } from '@angular/core';
import { AuthenticationService } from '../../../msn_services/authentication/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-msn-admin',
  templateUrl: './msn-admin.component.html',
  styleUrl: './msn-admin.component.scss'
})
export class MsnAdminComponent implements OnInit {

  isAuthenticated!: boolean;
  isAdmin!: boolean;
  _auth = inject(AuthenticationService);
  _router = inject(Router);

  ngOnInit(): void {

    this.isAuthenticated = this._auth.loggedIn();
    this.isAdmin = this._auth.isAdmin();
    if (!(this.isAuthenticated && this.isAdmin)) {
      this._router.navigate(['access_denied']);
    }
  }

}
