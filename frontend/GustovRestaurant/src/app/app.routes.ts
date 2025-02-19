import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'dashboard'
  },
  {
    path: '',
    loadChildren: () => import('./admin-features/main-layout/main-layout.routes')
  },
];
