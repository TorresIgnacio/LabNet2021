import { TestBed } from '@angular/core/testing';

import { NorthwindCustomersService } from './northwind-customers.service';

describe('NorthwindCustomersService', () => {
  let service: NorthwindCustomersService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(NorthwindCustomersService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
