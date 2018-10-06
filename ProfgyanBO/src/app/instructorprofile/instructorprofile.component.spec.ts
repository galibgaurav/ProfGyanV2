import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InstructorprofileComponent } from './instructorprofile.component';

describe('InstructorprofileComponent', () => {
  let component: InstructorprofileComponent;
  let fixture: ComponentFixture<InstructorprofileComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InstructorprofileComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InstructorprofileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
