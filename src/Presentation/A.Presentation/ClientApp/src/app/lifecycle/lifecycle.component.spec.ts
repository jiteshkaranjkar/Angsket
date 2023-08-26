import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LifecycleComponent } from './lifecycle.component';

describe('LifecycleComponent', () => {
  let component: LifecycleComponent;
  let fixture: ComponentFixture<LifecycleComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [LifecycleComponent]
    });
    fixture = TestBed.createComponent(LifecycleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
