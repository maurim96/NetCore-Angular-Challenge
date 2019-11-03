import { TestBed } from '@angular/core/testing';

import { CompetitionStoreService } from './competition-store.service';

describe('CompetitionStoreService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: CompetitionStoreService = TestBed.get(CompetitionStoreService);
    expect(service).toBeTruthy();
  });
});
