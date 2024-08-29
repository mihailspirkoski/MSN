import { AfterViewInit, Component, ElementRef, inject, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

import { AuthenticationService } from '../../../msn_services/authentication/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent implements OnInit, AfterViewInit {


  _authenticationService: AuthenticationService = inject(AuthenticationService);
  _router = inject(Router);
  _fb = inject(FormBuilder);
  @ViewChild("myinput") myInputElement!: ElementRef;
  registrationForm!: FormGroup;

  // registrationForm = new FormGroup({
  //   email: new FormControl(''),
  //   password: new FormControl(''),
  //   firstname: new FormControl(''),
  //   lastname: new FormControl(''),
  //   age: new FormControl('')
  // });

  ngOnInit(): void {
    this.registrationForm = this._fb.group({
      email: ['', Validators.required],
      password: ['', Validators.required],
      firstname: ['', Validators.required],
      lastname: ['', Validators.required],
      age: ['', Validators.required]
    });
  }


  ngAfterViewInit(): void {
    this.myInputElement.nativeElement.focus();
  }

  onSubmit() {
    this._authenticationService.register(this.registrationForm.value).subscribe({
      next: (data: any) => {
      },
      error: (err) => {
        console.log(err);
        if (err.status === 400 || err.status === 401 || err.status === 404) {
          localStorage.removeItem('token');
          this._router.navigate(['access_denied']);
        }
        localStorage.setItem('token', err.error.text);
        this._router.navigate(['home']);
        setTimeout(() => {
          location.reload();
        }, 0);

      }
    });

  }

}
