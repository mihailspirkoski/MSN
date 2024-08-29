import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllForumPostsComponent } from './all-forum-posts.component';

describe('AllForumPostsComponent', () => {
  let component: AllForumPostsComponent;
  let fixture: ComponentFixture<AllForumPostsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AllForumPostsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AllForumPostsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
