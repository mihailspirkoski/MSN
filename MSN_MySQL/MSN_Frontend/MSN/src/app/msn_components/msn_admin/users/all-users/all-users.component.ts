import { Component, inject, OnInit } from '@angular/core';
import { IMSNUser } from '../../../../msn_interfaces/iuser';
import { AuthenticationService } from '../../../../msn_services/authentication/authentication.service';
import { Router } from '@angular/router';
import { UsersService } from '../../../../msn_services/users/users.service';

@Component({
  selector: 'app-all-users',
  templateUrl: './all-users.component.html',
  styleUrl: './all-users.component.scss'
})
export class AllUsersComponent implements OnInit {

  allUsers: IMSNUser[] = [];
  isLoggedIn!: boolean;
  isAdmin!: boolean;
  _auth = inject(AuthenticationService);
  _router = inject(Router);
  _userService = inject(UsersService);

  ngOnInit(): void {

    this.isLoggedIn = this._auth.loggedIn();
    if (!this.isLoggedIn) {
      this._router.navigate(['login']);
    }
    this.isAdmin = this._auth.isAdmin();
    if (!this.isAdmin) {
      this._router.navigate(['access_denied']);
    }

    this._userService.getAllUsers().subscribe({
      next: (data: any) => {
        this.allUsers = data;
        console.log(this.allUsers);

      },
      error: (err) => {
        console.log(err);
      }
    });

  }
}
