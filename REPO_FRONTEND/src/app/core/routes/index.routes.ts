import { Routes } from '@angular/router';
import { IndexPageComponent } from '../pages/index-page/index-page.component';

export const indexRoutes: Routes = [
  {
    path: '',
    children: [
      { path: '', component:  IndexPageComponent},
    ],
  },
];
