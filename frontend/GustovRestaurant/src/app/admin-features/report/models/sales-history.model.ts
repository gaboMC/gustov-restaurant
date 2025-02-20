export class SalesHistory {
  id : number;
  saleDate: Date;
  dishName: string;
  dishQuantity: number;
  dishPrice: number;
  totalDishPrice: number;

  constructor(param: any) {
    this.id = param.id;
    this.saleDate = param.saleDate;
    this.dishName = param.dishName;
    this.dishQuantity = param.dishQuantity;
    this.dishPrice = param.dishPrice;
    this.totalDishPrice = param.totalDishPrice;
  }
}
