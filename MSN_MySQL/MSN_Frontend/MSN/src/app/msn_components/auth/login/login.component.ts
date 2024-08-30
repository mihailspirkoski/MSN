import { AfterViewInit, Component, ElementRef, inject, OnInit, ViewChild } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { AuthenticationService } from '../../../msn_services/authentication/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent implements OnInit, AfterViewInit {


  loginForm!: FormGroup;
  _authenticationService = inject(AuthenticationService);
  _router = inject(Router);
  _fb = inject(FormBuilder);
  @ViewChild("myinput") myInputField!: ElementRef;

  // loginForm = new FormGroup({
  //   email: new FormControl(''),
  //   password: new FormControl(''),
  // });

  ngOnInit(): void {
    this.loginForm = this._fb.group({
      email: ['', Validators.required],
      password: ['', Validators.required]
    });
  }


  ngAfterViewInit(): void {
    this.myInputField.nativeElement.focus();
  }

  onSubmit() {
    this._authenticationService.login(this.loginForm.value).subscribe({
      next: (data: any) => {
      },
      error: (err) => {
        console.log(err);
        localStorage.setItem('token', err.error.text);
        this._router.navigate(['home']);
        setTimeout(() => {
          location.reload();
        }, 0);
        if (err.status === 400 || err.status === 401 || err.status === 404) {
          localStorage.removeItem('token');
          this._router.navigate(['access_denied']);
        }
      }
    });
  }

  getEmail() {
    return this.loginForm.get('email');
  }
  getPassword() {
    return this.loginForm.get('password');
  }

}
