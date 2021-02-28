import { TestBed } from '@angular/core/testing';

import { LocationResolver } from './location.resolver';

describe('LocationResolver', () => {
  let resolver: LocationResolver;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    resolver = TestBed.inject(LocationResolver);
  });

  it('should be created', () => {
    expect(resolver).toBeTruthy();
  });
});
