import { TestBed } from '@angular/core/testing';

import { GoogleApiModuleService } from './google-api-module.service';

describe('GoogleApiModuleService', () => {
  let service: GoogleApiModuleService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GoogleApiModuleService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
