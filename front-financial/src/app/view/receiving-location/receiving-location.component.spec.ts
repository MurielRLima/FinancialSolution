import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReceivingLocationComponent } from './receiving-location.component';

describe('ReceivingLocationComponent', () => {
  let component: ReceivingLocationComponent;
  let fixture: ComponentFixture<ReceivingLocationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReceivingLocationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReceivingLocationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
