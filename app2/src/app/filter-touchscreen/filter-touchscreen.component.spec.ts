import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FilterTouchscreenComponent } from './filter-touchscreen.component';

describe('FilterTouchscreenComponent', () => {
  let component: FilterTouchscreenComponent;
  let fixture: ComponentFixture<FilterTouchscreenComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FilterTouchscreenComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FilterTouchscreenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
