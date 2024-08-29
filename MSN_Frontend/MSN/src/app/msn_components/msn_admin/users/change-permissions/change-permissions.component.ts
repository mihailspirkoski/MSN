import { AfterViewInit, Component, ElementRef, inject, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { IMSNUser } from '../../../../msn_interfaces/iuser';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthenticationService } from '../../../../msn_services/authentication/authentication.service';
import { ActivatedRoute, Router } from '@angular/router';
import { UsersService } from '../../../../msn_services/users/users.service';

@Component({
  selector: 'app-change-permissions',
  templateUrl: './change-permissions.component.html',
  styleUrl: './change-permissions.component.scss'
})
export class ChangePermissionsComponent implements OnInit, AfterViewInit, OnDestroy {

  id: any;
  user!: IMSNUser;
  isLoggedIn!: boolean;
  isAdmin!: boolean;
  _fb = inject(FormBuilder);
  _auth = inject(AuthenticationService);
  _router = inject(Router);
  _userService = inject(UsersService);
  _route = inject(ActivatedRoute);
  changeRoleForm!: FormGroup;
  @ViewChild("myinput") myInputField!: ElementRef;

  ngOnInit(): void {

    this.isLoggedIn = this._auth.loggedIn();
    if (!this.isLoggedIn) {
      this._router.navigate(['login']);
    }
    this.isAdmin = this._auth.isAdmin();
    if (!this.isAdmin) {
      this._router.navigate(['access_denied']);
    }

    this.id = this._route.snapshot.paramMap.get("email");
    this._userService._url_getUser = this._userService._url_getUser + this.id;
    this._userService.getUser().subscribe({
      next: (data: any) => {
        this.user = data;
        if (this.user === null) {
          this._router.navigate(['access_denied']);
        }
      },
      error: (err) => {
        console.log(err);
      }
    });

    this.changeRoleForm = this._fb.group({
      email: ['', Validators.required],
      role: ['', Validators.required],
    });
  }

  ngAfterViewInit(): void {
    this.myInputField.nativeElement.focus();
  }

  ngOnDestroy() {
    location.reload();
  }

  onSubmit() {
    return this._userService.changePermission(this.changeRoleForm.value).subscribe({
      next: (data: any) => {
        this._router.navigate(['all_users']);
      },
      error: (err) => {
        console.log(err);
        this._router.navigate(['all_users']);
      }
    });
  }

}
