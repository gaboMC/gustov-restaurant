import { SaleDetailInterface } from "./sale-detail.interface";

export interface SaleInterface {
  date: string;
  total: number;
  userId: number;
  saleDetails: SaleDetailInterface[];
}

export interface SaleReportInterface {
  id: number,
  date: string,
  total: number
}
