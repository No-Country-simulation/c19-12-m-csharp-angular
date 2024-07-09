import { Routes } from '@angular/router';
import { DashboardLayoutComponent } from '../layouts/dashboard-layout/dashboard-layout.component';
import { DashboardPageComponent } from '../pages/dashboard-page/dashboard-page.component';

export const dashboardRoutes: Routes = [
  {
    path: '',
    component: DashboardLayoutComponent,
    children: [
      { path: '', component: DashboardPageComponent },
      {
        path: '**',
        redirectTo: '',
      },
    ],
  },
];
