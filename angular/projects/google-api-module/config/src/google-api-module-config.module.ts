import { ModuleWithProviders, NgModule } from '@angular/core';
import { GOOGLE_API_MODULE_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class GoogleApiModuleConfigModule {
  static forRoot(): ModuleWithProviders<GoogleApiModuleConfigModule> {
    return {
      ngModule: GoogleApiModuleConfigModule,
      providers: [GOOGLE_API_MODULE_ROUTE_PROVIDERS],
    };
  }
}
