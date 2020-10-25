import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FilterWeightComponent } from './filter-weight.component';

describe('FilterWeightComponent', () => {
  let component: FilterWeightComponent;
  let fixture: ComponentFixture<FilterWeightComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FilterWeightComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FilterWeightComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
