import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MsnAdminComponent } from './msn-admin.component';

describe('MsnAdminComponent', () => {
  let component: MsnAdminComponent;
  let fixture: ComponentFixture<MsnAdminComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [MsnAdminComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MsnAdminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
