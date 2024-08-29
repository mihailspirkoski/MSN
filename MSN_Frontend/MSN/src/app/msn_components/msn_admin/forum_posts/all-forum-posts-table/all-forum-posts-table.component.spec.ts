import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllForumPostsTableComponent } from './all-forum-posts-table.component';

describe('AllForumPostsTableComponent', () => {
  let component: AllForumPostsTableComponent;
  let fixture: ComponentFixture<AllForumPostsTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AllForumPostsTableComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AllForumPostsTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
