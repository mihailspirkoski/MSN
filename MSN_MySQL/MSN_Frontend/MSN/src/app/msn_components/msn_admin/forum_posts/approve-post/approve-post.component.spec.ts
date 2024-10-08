import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApprovePostComponent } from './approve-post.component';

describe('ApprovePostComponent', () => {
  let component: ApprovePostComponent;
  let fixture: ComponentFixture<ApprovePostComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ApprovePostComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ApprovePostComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
