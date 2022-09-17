import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'GoogleApiModule',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44329',
    redirectUri: baseUrl,
    clientId: 'GoogleApiModule_App',
    responseType: 'code',
    scope: 'offline_access GoogleApiModule',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44329',
      rootNamespace: 'Byteology.GoogleApiModule',
    },
    GoogleApiModule: {
      url: 'https://localhost:44350',
      rootNamespace: 'Byteology.GoogleApiModule',
    },
  },
} as Environment;
