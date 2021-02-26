import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClubListStateComponent } from './club-list-state.component';

describe('ClubListStateComponent', () => {
  let component: ClubListStateComponent;
  let fixture: ComponentFixture<ClubListStateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClubListStateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ClubListStateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
