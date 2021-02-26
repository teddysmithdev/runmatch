import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SidebarStatesComponent } from './sidebar-states.component';

describe('SidebarStatesComponent', () => {
  let component: SidebarStatesComponent;
  let fixture: ComponentFixture<SidebarStatesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SidebarStatesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SidebarStatesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
