import { Routes } from '@angular/router';
import { DashboardLayoutComponent } from '../layouts/dashboard-layout/dashboard-layout.component';
import { DashboardPageComponent } from '../pages/dashboard-page/dashboard-page.component';
import { JobsPageComponent } from '../pages/jobs-page/jobs-page.component';
import { AdminsPageComponent } from '../pages/admins-page/admins-page.component';

export const dashboardRoutes: Routes = [
  {
    path: '',
    component: DashboardLayoutComponent,
    children: [
      { path: '', component: DashboardPageComponent },
      { path: 'jobs', component: JobsPageComponent },
      { path: 'admins', component: AdminsPageComponent },
      {
        path: '**',
        redirectTo: '',
      },
    ],
  },
];
