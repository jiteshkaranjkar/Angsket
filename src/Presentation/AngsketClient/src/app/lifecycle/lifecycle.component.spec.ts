import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LifeCycleComponent } from './lifecycle.component';

describe('LifeCycleComponent', () => {
  let component: LifeCycleComponent;
  let fixture: ComponentFixture<LifeCycleComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [LifeCycleComponent]
    });
    fixture = TestBed.createComponent(LifeCycleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
