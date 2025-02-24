import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'dashboard'
  },
  {
    path: '',
    loadChildren: () => import('./admin-features/views/main-layout/main-layout.routes')
  },
];
