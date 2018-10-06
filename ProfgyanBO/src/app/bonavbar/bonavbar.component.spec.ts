import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BonavbarComponent } from './bonavbar.component';

describe('BonavbarComponent', () => {
  let component: BonavbarComponent;
  let fixture: ComponentFixture<BonavbarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BonavbarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BonavbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
