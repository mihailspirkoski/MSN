import { AfterViewInit, Component, ElementRef, inject, OnInit, ViewChild } from '@angular/core';
import { ForumPostService } from '../../../msn_services/forum_post/forum-post.service';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { AuthenticationService } from '../../../msn_services/authentication/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-post',
  templateUrl: './create-post.component.html',
  styleUrl: './create-post.component.scss'
})
export class CreatePostComponent implements OnInit, AfterViewInit {

  _forumPostService = inject(ForumPostService);
  isLoggedIn!: boolean;
  _authService = inject(AuthenticationService);
  _router = inject(Router);
  _fb = inject(FormBuilder);
  @ViewChild("myinput") myInputField!: ElementRef;

  postForm!: FormGroup;

  // postForm = new FormGroup({
  //   title: new FormControl(''),
  //   artist: new FormControl(''),
  //   type: new FormControl(''),
  //   genre: new FormControl(''),
  //   description: new FormControl('')
  // });

  ngOnInit(): void {
    this.isLoggedIn = this._authService.loggedIn()
    if (!this.isLoggedIn) {
      this._router.navigate(['login']);
    }
    console.log(this._authService.isAdmin());
    console.log(this._authService.isUser());


    this.postForm = this._fb.group({
      title: ['', Validators.required],
      artist: ['', Validators.required],
      type: ['', Validators.required],
      genre: ['', Validators.required],
      description: ['']
    });
  }

  ngAfterViewInit(): void {
    this.myInputField.nativeElement.focus();
  }

  onSubmit() {
    this._forumPostService.createPost(this.postForm.value).subscribe({
      next: (data: any) => {
        console.log(data);
        this._router.navigate(['forum_posts']);
      },
      error: (err) => {
        console.log(err);
        this._router.navigate(['forum_posts']);
        setTimeout(() => {
          location.reload();
        }, 0);
      }
    });
  }

}
