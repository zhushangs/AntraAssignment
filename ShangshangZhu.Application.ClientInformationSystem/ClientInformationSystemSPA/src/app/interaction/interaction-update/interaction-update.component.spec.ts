import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InteractionUpdateComponent } from './interaction-update.component';

describe('InteractionUpdateComponent', () => {
  let component: InteractionUpdateComponent;
  let fixture: ComponentFixture<InteractionUpdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InteractionUpdateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InteractionUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
