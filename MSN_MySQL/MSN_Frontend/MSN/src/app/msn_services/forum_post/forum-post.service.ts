import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { IForumPost } from '../../msn_interfaces/iforumpost';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ForumPostService {

  _url_createPost = 'https://localhost:7203/api/ForumPost/add-post';
  _url_getAllPosts = 'https://localhost:7203/api/ForumPost/get-all-posts';
  _url_getSinglePost = 'https://localhost:7203/api/ForumPost/get-single-post/';
  _url_approvePost = 'https://localhost:7203/api/ForumPost/approve-post';

  _http = inject(HttpClient);

  createPost(postData: any) {
    return this._http.post<any>(this._url_createPost, postData);
  }

  getAllPosts(): Observable<IForumPost[]> {
    return this._http.get<IForumPost[]>(this._url_getAllPosts);
  }

  getSingleForumPost(): Observable<IForumPost> {
    return this._http.get<IForumPost>(this._url_getSinglePost);
  }

  approvePost(postToApprove: IForumPost) {
    return this._http.post<IForumPost>(this._url_approvePost, postToApprove);
  }

  constructor() { }
}
