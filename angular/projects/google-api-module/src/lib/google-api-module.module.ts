import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { GoogleApiModuleComponent } from './components/google-api-module.component';
import { GoogleApiModuleRoutingModule } from './google-api-module-routing.module';

@NgModule({
  declarations: [GoogleApiModuleComponent],
  imports: [CoreModule, ThemeSharedModule, GoogleApiModuleRoutingModule],
  exports: [GoogleApiModuleComponent],
})
export class GoogleApiModuleModule {
  static forChild(): ModuleWithProviders<GoogleApiModuleModule> {
    return {
      ngModule: GoogleApiModuleModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<GoogleApiModuleModule> {
    return new LazyModuleFactory(GoogleApiModuleModule.forChild());
  }
}
