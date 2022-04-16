import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReceivingLocationEditComponent } from './receiving-location-edit.component';

describe('ReceivingLocationEditComponent', () => {
  let component: ReceivingLocationEditComponent;
  let fixture: ComponentFixture<ReceivingLocationEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReceivingLocationEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReceivingLocationEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
