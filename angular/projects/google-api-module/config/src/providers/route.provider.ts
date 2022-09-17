import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';
import { eGoogleApiModuleRouteNames } from '../enums/route-names';

export const GOOGLE_API_MODULE_ROUTE_PROVIDERS = [
  {
    provide: APP_INITIALIZER,
    useFactory: configureRoutes,
    deps: [RoutesService],
    multi: true,
  },
];

export function configureRoutes(routesService: RoutesService) {
  return () => {
    routesService.add([
      {
        path: '/google-api-module',
        name: eGoogleApiModuleRouteNames.GoogleApiModule,
        iconClass: 'fas fa-book',
        layout: eLayoutType.application,
        order: 3,
      },
    ]);
  };
}
