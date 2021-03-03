import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FamousBlogsComponent } from './famous-blogs.component';

describe('FamousBlogsComponent', () => {
  let component: FamousBlogsComponent;
  let fixture: ComponentFixture<FamousBlogsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FamousBlogsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FamousBlogsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
