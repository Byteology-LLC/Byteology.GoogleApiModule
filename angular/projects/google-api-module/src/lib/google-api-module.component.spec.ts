import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { GoogleApiModuleComponent } from './google-api-module.component';

describe('GoogleApiModuleComponent', () => {
  let component: GoogleApiModuleComponent;
  let fixture: ComponentFixture<GoogleApiModuleComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ GoogleApiModuleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GoogleApiModuleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
