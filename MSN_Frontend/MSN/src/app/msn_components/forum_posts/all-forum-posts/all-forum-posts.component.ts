import { Component, inject, OnInit } from '@angular/core';
import { IForumPost } from '../../../msn_interfaces/iforumpost';
import { ForumPostService } from '../../../msn_services/forum_post/forum-post.service';

@Component({
  selector: 'app-all-forum-posts',
  templateUrl: './all-forum-posts.component.html',
  styleUrl: './all-forum-posts.component.scss'
})
export class AllForumPostsComponent implements OnInit {


  forumPosts: IForumPost[] = [];

  _forumPostService = inject(ForumPostService);


  ngOnInit(): void {
    this._forumPostService.getAllPosts().subscribe({
      next: (data: any) => {
        this.forumPosts = data;
      },
      error: (err) => {
        console.log(err);
      }
    });
  }


}
