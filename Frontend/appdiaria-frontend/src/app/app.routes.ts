import { Routes } from '@angular/router';
import { Home } from './features/home/home';
import { MainLayout } from './layout/main-layout/main-layout';
import { Dashboard } from './features/dashboard/dashboard';

export const routes: Routes = [
 {
    path: '',
    component: Home
  },
  {
    path: 'app',
    component: MainLayout,
    children: [
      {
        path: 'dashboard',
        component: Dashboard
      }
    ]
  }
];
