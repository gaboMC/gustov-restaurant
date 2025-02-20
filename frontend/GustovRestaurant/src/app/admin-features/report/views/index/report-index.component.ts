import { Component, Inject, Injectable } from '@angular/core';
import { SalesHistory } from '../../models/sales-history.model';
import { ReportService } from '../../services/report.service';

@Component({
  selector: 'app-report-index',
  standalone: true,
  imports: [],
  templateUrl: './report-index.component.html',
  styleUrl: './report-index.component.scss'
})
export class ReportIndexComponent {
     salesHistoryList: SalesHistory[];
     #reportSales = Inject(ReportService)

     constructor() {
      this.salesHistoryList = [
        {
          id: 1,
          saleDate: new Date('2025-02-20T10:00:00'),
          dishName: 'Spaghetti Bolognese',
          dishQuantity: 2,
          dishPrice: 12.50,
          totalDishPrice: 25.00
        },
        {
          id: 2,
          saleDate: new Date('2025-02-20T11:30:00'),
          dishName: 'Caesar Salad',
          dishQuantity: 1,
          dishPrice: 8.00,
          totalDishPrice: 8.00
        },
        {
          id: 3,
          saleDate: new Date('2025-02-20T12:00:00'),
          dishName: 'Margherita Pizza',
          dishQuantity: 3,
          dishPrice: 10.00,
          totalDishPrice: 30.00
        },
        {
          id: 4,
          saleDate: new Date('2025-02-20T14:30:00'),
          dishName: 'Penne Arrabbiata',
          dishQuantity: 1,
          dishPrice: 9.00,
          totalDishPrice: 9.00
        },
        {
          id: 5,
          saleDate: new Date('2025-02-20T16:00:00'),
          dishName: 'Cheeseburger',
          dishQuantity: 2,
          dishPrice: 15.00,
          totalDishPrice: 30.00
        }
      ];
     }


     printReport(): void {
      this.#reportSales.printSalesDaily$(this.salesHistoryList);
     }
    }
