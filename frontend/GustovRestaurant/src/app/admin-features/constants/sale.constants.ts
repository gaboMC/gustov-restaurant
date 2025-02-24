import { SaleInterface } from "@gustov/admin-features/models";

export const INITIAL_SALE: SaleInterface = {
  date: new Date().toISOString(),
  total: 0,
  userId: 1,
  saleDetails: []
};
