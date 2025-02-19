import { Routes } from '@angular/router';
import { MainLayoutComponent } from './views/main-layout/main-layout.component';
import { MainDashboardComponent } from './views/main-dashboard/main-dashboard.component';
import { DishComponent } from '../dish/index/index.component';

export const mainLayoutRoutes: Routes = [
  {
    path: '',
    component: MainLayoutComponent,
    children: [
      { path: 'dashboard', component: MainDashboardComponent },
      { path: 'dish', component: DishComponent },
      //{ path: 'sale', component: SaleComponent },
      //{ path: 'report', component: ReportComponent },
      { path: '**', redirectTo: 'dashboard' }
    ]
  }
];

export default mainLayoutRoutes;
