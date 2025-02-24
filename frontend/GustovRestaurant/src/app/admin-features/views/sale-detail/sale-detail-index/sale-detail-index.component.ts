import { Component, inject } from '@angular/core';
import { SaleDetailReportInterface } from '@gustov/admin-features/models';
import { SaleDetailService } from '@gustov/admin-features/services';
import { ApiResponseInterface } from '@gustov/core/models';
import { GustovTableBodyDirective } from '../../../../shared/directives/table-body.directive';
import { GustovTableTheadDirective } from '../../../../shared/directives/table-thead.directive';
import { GustovPrimaryButtonDirective } from '../../../../shared/directives/primary-button.directive';
import { GustovInputDirective } from '../../../../shared/directives/input.directive';
import { SvgIconComponent } from 'angular-svg-icon';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-sale-detail-index',
  standalone: true,
  imports: [GustovTableBodyDirective,
            GustovTableTheadDirective,
            GustovPrimaryButtonDirective,
            GustovInputDirective,
            SvgIconComponent,
            FormsModule],
  templateUrl: './sale-detail-index.component.html',
  styleUrl: './sale-detail-index.component.scss'
})
export class SaleDetailIndexComponent {
  #saleDetailService = inject(SaleDetailService);

  saleDetails: SaleDetailReportInterface[] = [];
  selectedDate: string = "";

  constructor() {
    this.loadSaleDetailReport("2025-01-01");
  }

  filterReportByDate(filterDate: string) {
    console.log(filterDate);
    this.loadSaleDetailReport(filterDate);
  }

  getTotal() {
    return this.saleDetails.reduce((sum, item) => sum + (item.quantity * item.price), 0)
  }

  loadSaleDetailReport(filterDate: string) {
      this.#saleDetailService.getAll$(filterDate).subscribe({
        next: (response: ApiResponseInterface<Array<SaleDetailReportInterface>>) => {
          if (response.isSuccess) {
            this.saleDetails = response.data;
          } else {
            console.log("Error al cargar los platos", response.errors);
          }
        },
        error: (error) => console.log("Error al obtener platos:", error)
      });
    }
}
