import { Component, inject } from '@angular/core';
import { AuthenticationService } from '../../../msn_services/authentication/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrl: './logout.component.scss'
})
export class LogoutComponent {

  _authenticationService = inject(AuthenticationService);
  _router = inject(Router);


  onSubmit() {
    this._authenticationService.logout();
    this._router.navigate(['home']);
    setTimeout(() => {
      location.reload();
    }, 0);

  }

}
