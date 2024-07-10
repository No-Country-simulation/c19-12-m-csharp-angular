import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadChildren: () =>
      import('./core/routes/index.routes').then((m) => m.indexRoutes),
  },
  {
    path: 'auth',
    //TODO: GUARD isNotAuthenticated
    loadChildren: () =>
      import('./auth/routes/auth.routes').then((m) => m.authRoutes),
  },
  {
    path: 'dashboard',
    //TODO : GUARD isAuthenticated
    loadChildren: () =>
      import('./core/routes/dashboard.routes').then((m) => m.dashboardRoutes),
  },
  {
    path: '**',
    redirectTo: '/',
  },
];
