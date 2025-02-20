import { Component, DestroyRef, inject } from "@angular/core";
import { SaleDetailService, SaleService } from "../services";
import { SaleModel } from "../models/sale.model";
import { FormControl, FormGroup, ReactiveFormsModule } from "@angular/forms";
import { map, pluck, switchMap, tap } from "rxjs";
import { ApiResponseInterface } from "@gustov/core/models";
import { SaleDetailInterface } from "../models/sale-detail.model";
import { SvgIconComponent } from "angular-svg-icon";
import { GustovInputDirective } from "../../../shared/directives/input.directive";
import { GustovPrimaryButtonDirective } from "../../../shared/directives/primary-button.directive";
import { GustovTableBodyDirective } from "../../../shared/directives/table-body.directive";
import { GustovTableTheadDirective } from "../../../shared/directives/table-thead.directive";

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
  #saleDetailService = inject(SaleDetailService);
  #destroyRef = inject(DestroyRef);

  saleId: number | null = null;
  saleTotal: number = 0;
  saleDetails: SaleDetailInterface[] = [];

  saleGroup!: FormGroup;
  saleDetailGroup!: FormGroup;

  constructor(){
      this.#saleDetailService.getAll$().subscribe({
        next: (response) => {
          if (response.isSuccess) {
            this.saleDetails = response.data;
          } else {
            console.error('Error al obtener detalles de venta', response.message);
          }
        },
        error: (error) => {
          console.error('Error en la petición', error);
        }
      });
    }

  onAddDetail(): void {
    if (this.saleDetailGroup.invalid) {
      this.saleDetailGroup.markAllAsTouched();
      return;
    }

    const saleDetail: SaleDetailInterface = this.saleDetailGroup.value;

    this.#saleDetailService.save$(saleDetail, this.#destroyRef).subscribe({
      next: (response) => {
        if (response.isSuccess) {
          console.log('Detalle de venta registrado con éxito');
          this.saleDetailGroup.reset();
        } else {
          console.error('Error al registrar el detalle de venta', response.message);
        }
      },
      error: (error) => {
        console.error('Error en la petición', error);
      }
    });
  }

  onDeleteDetail(id: number){

  }

  close(){

  }

}
