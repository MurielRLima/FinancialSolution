import { TestBed } from '@angular/core/testing';

import { ReceivingLocationServiceService } from './receiving-location-service.service';

describe('ReceivingLocationServiceService', () => {
  let service: ReceivingLocationServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ReceivingLocationServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
