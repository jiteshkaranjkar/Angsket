import { TestBed } from '@angular/core/testing';

import { OpenaiService } from './open-ai.service';

describe('OpenaiService', () => {
  let service: OpenaiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OpenaiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
