import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FilterDisplaySizeComponent } from './filter-display-size.component';

describe('FilterDisplaySizeComponent', () => {
  let component: FilterDisplaySizeComponent;
  let fixture: ComponentFixture<FilterDisplaySizeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FilterDisplaySizeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FilterDisplaySizeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
