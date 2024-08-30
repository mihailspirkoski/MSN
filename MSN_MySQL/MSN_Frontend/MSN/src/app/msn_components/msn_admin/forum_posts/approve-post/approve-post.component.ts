import { AfterViewInit, Component, ElementRef, inject, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { IForumPost } from '../../../../msn_interfaces/iforumpost';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthenticationService } from '../../../../msn_services/authentication/authentication.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ForumPostService } from '../../../../msn_services/forum_post/forum-post.service';

@Component({
  selector: 'app-approve-post',
  templateUrl: './approve-post.component.html',
  styleUrl: './approve-post.component.scss'
})
export class ApprovePostComponent implements OnInit, AfterViewInit, OnDestroy {

  id: any;
  forumPost!: IForumPost;
  isLoggedIn!: boolean;
  isAdmin!: boolean;
  _fb = inject(FormBuilder);
  _auth = inject(AuthenticationService);
  _router = inject(Router);
  _forumPostService = inject(ForumPostService);
  _route = inject(ActivatedRoute);
  approvePostForm!: FormGroup;
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

    this.id = this._route.snapshot.paramMap.get("id");
    this._forumPostService._url_getSinglePost = this._forumPostService._url_getSinglePost + this.id;
    this._forumPostService.getSingleForumPost().subscribe({
      next: (data: any) => {
        this.forumPost = data;
        if (this.forumPost === null) {
          this._router.navigate(['access_denied']);
        }
      },
      error: (err) => {
        console.log(err);
      }
    });

    this.approvePostForm = this._fb.group({
      id: ['', Validators.required],
      title: ['', Validators.required],
      artist: ['', Validators.required],
      genre: ['', Validators.required],
      type: ['', Validators.required],
      description: ['', Validators.required],
      isApproved: ['', Validators.required],
      timeCreated: ['', Validators.required],
      userName: ['', Validators.required],
      createdBy: ['']
    })
  }

  ngAfterViewInit(): void {
    this.myInputField.nativeElement.focus();
  }

  ngOnDestroy() {
    location.reload();
  }

  onSubmit() {
    return this._forumPostService.approvePost(this.approvePostForm.value).subscribe({
      next: (data: any) => {
        this._router.navigate(['all_forum_posts']);
      },
      error: (err) => {
        console.log(err);
        this._router.navigate(['all_forum_posts']);
      }
    });
  }

}
