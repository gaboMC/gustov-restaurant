export class SaleModel {
  id : number;
  date: Date;
  total: number;
  userId: number;

  constructor(param: any) {
    this.id = 0;
    this.date = param.date;
    this.total = param.total;
    this.userId = 1;
  }
}
