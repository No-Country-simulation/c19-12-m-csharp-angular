import { Routes } from '@angular/router';
import { IndexComponent } from './core/components/index/index.component';
import { LoginComponent } from './auth/components/login/login.component';

export const routes: Routes = [
    {
        path: '',
        component: IndexComponent,
    },
    {
        path: 'login',
        component: LoginComponent,
    }
];
