import { Component, inject, OnInit } from '@angular/core';
import { IForumPost } from '../../../../msn_interfaces/iforumpost';
import { AuthenticationService } from '../../../../msn_services/authentication/authentication.service';
import { ForumPostService } from '../../../../msn_services/forum_post/forum-post.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-all-forum-posts-table',
  templateUrl: './all-forum-posts-table.component.html',
  styleUrl: './all-forum-posts-table.component.scss'
})
export class AllForumPostsTableComponent implements OnInit {

  allForumPosts: IForumPost[] = [];
  isLoggedIn!: boolean;
  isAdmin!: boolean;
  _auth = inject(AuthenticationService);
  _router = inject(Router);
  _forumPostService = inject(ForumPostService);

  ngOnInit(): void {

    this.isLoggedIn = this._auth.loggedIn();
    if (!this.isLoggedIn) {
      this._router.navigate(['login']);
    }
    this.isAdmin = this._auth.isAdmin();
    if (!this.isAdmin) {
      this._router.navigate(['access_denied']);
    }

    this._forumPostService.getAllPosts().subscribe({
      next: (data: any) => {
        this.allForumPosts = data;
      },
      error: (err) => {
        console.log(err);
      }
    });

  }
}
