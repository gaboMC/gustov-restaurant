import { Component, DestroyRef, inject } from "@angular/core";
import { FormControl, FormGroup, ReactiveFormsModule } from "@angular/forms";
import { ApiResponseInterface } from "@gustov/core/models";
import { SvgIconComponent } from "angular-svg-icon";
import { GustovInputDirective } from "../../../../shared/directives/input.directive";
import { GustovPrimaryButtonDirective } from "../../../../shared/directives/primary-button.directive";
import { GustovTableBodyDirective } from "../../../../shared/directives/table-body.directive";
import { GustovTableTheadDirective } from "../../../../shared/directives/table-thead.directive";
import { DishService, SaleService } from "@gustov/admin-features/services";
import { SaleInterface } from "../../../models/sale.interface";
import { DishInterface, SaleDetailInterface } from "@gustov/admin-features/models";
import { INITIAL_SALE } from "../../../constants";

@Component({
  selector: "app-sale",
  standalone: true,
  imports: [ReactiveFormsModule,
            SvgIconComponent,
            GustovInputDirective,
            GustovPrimaryButtonDirective,
            GustovTableBodyDirective,
            GustovTableTheadDirective],
  templateUrl: "./sale-index.component.html",
  styleUrls: ["./sale-index.component.scss"],
})
export class SaleIndexComponent {
  #saleService = inject(SaleService);
  #destroyRef = inject(DestroyRef);
  #dishService = inject(DishService);

  dishes: DishInterface[] = [];

  sale: SaleInterface = { ...INITIAL_SALE};
  saleGroup!: FormGroup;
  saleDetailGroup!: FormGroup;

  constructor(){
    this.#initializeComponent();
    this.loadDishes();
  }

  addSaleDetail(): void{
    const { product, quantity} = this.saleDetailGroup.value;
    if(product && quantity > 0) {
      const newSaleDetail = {
        dishId: product.id,
        dishName: product.name,
        price: product.price,
        quantity: quantity,
        total: product.price * quantity,
      };
      this.sale.saleDetails.push(newSaleDetail);
      this.calculateTotalSale();
      this.saleDetailGroup.reset();
      console.log(this.sale);
    }
  }

  onDeleteDetail(detailId: number) {
  const detailIndex = this.sale.saleDetails.findIndex(item => item.dishId === detailId);

    if (detailIndex !== -1) {
      this.sale.saleDetails.splice(detailIndex, 1);
      this.calculateTotalSale();
    } else {
      console.error('El detalle no existe');
    }
    //console.log(this.sale.saleDetails);
  }

  calculateTotalSale(): void{
    const total = this.sale.saleDetails.reduce((sum, item) => sum + (item.quantity * item.price), 0);
    this.sale.total = total;
    this.saleGroup.patchValue({ total: this.sale.total });
  }

  saveSale(): void{
    this.sale.date = new Date().toISOString();
    console.log(this.sale);
    this.#saleService.save$(this.sale as SaleInterface, this.#destroyRef)
    .subscribe({
      next: (response: ApiResponseInterface<boolean>) => {
        if (response.isSuccess) {
          console.log("Venta guardada con éxito");
          this.sale = {...INITIAL_SALE}
          this.saleGroup.reset();
          this.saleDetailGroup.reset();
          this.sale.saleDetails = [];
        } else {
          console.log("Error al guardar la venta", response.errors);
        }
      },
      error: (e) => console.error("Error en la solicitud:", e)
    });
  }

  #initializeComponent(){
    this.saleGroup = new FormGroup({
      date: new FormControl<string | null>(this.sale.date),
      total: new FormControl<number | null>(this.sale.total),
      userId: new FormControl<number | null>(this.sale.userId),
      saleDetails: new FormControl<SaleDetailInterface[]>(this.sale.saleDetails = [])
    });

    this.saleDetailGroup = new FormGroup({
      product: new FormControl<string | null>(""),
      quantity: new FormControl<number | null>(0),
      price: new FormControl<number | null>(0),
    });
  }

  loadDishes() {
    this.#dishService.getAll$().subscribe({
      next: (response: ApiResponseInterface<Array<DishInterface>>) => {
        if (response.isSuccess) {
          this.dishes = response.data;
        } else {
          console.log("Error al cargar los platos", response.errors);
        }
      },
      error: (error) => console.log("Error al obtener platos:", error)
    });
  }

}
