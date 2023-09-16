import { ModuleWithProviders, NgModule } from '@angular/core';
import { ConfigurationService } from './services/ConfigurationService';

@NgModule({
  imports: []
})

export class SharedModule {
  static forRoot(): ModuleWithProviders<SharedModule> {
    return {
      ngModule: SharedModule,
      providers: [
        ConfigurationService
      ]
    }
  }
}
