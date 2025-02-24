import { DishReportInterface } from "./dish.interface";
import { SaleReportInterface } from "./sale.interface";

export interface SaleDetailInterface {
  dishId: number;
  dishName: string;
  quantity: number;
  price: number;
}

export interface SaleDetailReportInterface {
  id: number,
  saleId: number,
  sale: SaleReportInterface
  dishId: number;
  dish: DishReportInterface
  quantity: number;
  price: number;
}
