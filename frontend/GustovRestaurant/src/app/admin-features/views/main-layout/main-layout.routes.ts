import { Routes } from '@angular/router';
import { MainLayoutComponent } from './views/main-layout/main-layout.component';
import { DishIndexComponent } from '../dish/index/dish-index.component';
import { SaleIndexComponent } from '../sale/index/sale-index.component';
import { SaleDetailIndexComponent } from '../sale-detail/sale-detail-index/sale-detail-index.component';
import { ReportIndexComponent } from '../report/views/index/report-index.component';


export const mainLayoutRoutes: Routes = [
  {
    path: '',
    component: MainLayoutComponent,
    children: [
      //{ path: 'dashboard', component: MainDashboardComponent },
      { path: 'dish', component: DishIndexComponent },
      { path: 'sale', component: SaleIndexComponent },
      { path: 'sale-detail', component: SaleDetailIndexComponent },
      //{ path: 'report', component: ReportIndexComponent },
      { path: '**', redirectTo: 'dish' }
    ]
  }
];

export default mainLayoutRoutes;
