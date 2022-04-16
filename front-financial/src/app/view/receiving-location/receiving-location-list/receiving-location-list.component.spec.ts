import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReceivingLocationListComponent } from './receiving-location-list.component';

describe('ReceivingLocationListComponent', () => {
  let component: ReceivingLocationListComponent;
  let fixture: ComponentFixture<ReceivingLocationListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReceivingLocationListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReceivingLocationListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
