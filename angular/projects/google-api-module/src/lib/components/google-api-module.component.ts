import { Component, OnInit } from '@angular/core';
import { GoogleApiModuleService } from '../services/google-api-module.service';

@Component({
  selector: 'lib-google-api-module',
  template: ` <p>google-api-module works!</p> `,
  styles: [],
})
export class GoogleApiModuleComponent implements OnInit {
  constructor(private service: GoogleApiModuleService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
