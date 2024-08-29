import { Component, inject, OnInit } from '@angular/core';
import { AuthenticationService } from '../../msn_services/authentication/authentication.service';

@Component({
  selector: 'app-header-component',
  templateUrl: './header-component.component.html',
  styleUrl: './header-component.component.scss'
})
export class HeaderComponentComponent implements OnInit {


  _authService = inject(AuthenticationService);

  fullnameUser!: string;
  isAuthenticated!: boolean;
  isAdmin!: boolean;

  ngOnInit(): void {
    this.fullnameUser = this._authService.getFullnameFromToken();
    this.isAuthenticated = this._authService.loggedIn();
    this.isAdmin = this._authService.isAdmin();
  }


}
