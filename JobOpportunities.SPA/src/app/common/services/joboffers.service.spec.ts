import { TestBed } from '@angular/core/testing';

import { JobOffersService } from './JobOffers.service';

describe('jobOffersService', () => {
  let service: JobOffersService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(JobOffersService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
