import { HttpClient } from "@angular/common/http";
import { DestroyRef, inject, Injectable } from "@angular/core";
import { environment } from "../../../../environments/environment.development";
import { ApiResponseInterface } from "@gustov/core/models";
import { takeUntilDestroyed } from "@angular/core/rxjs-interop";
import { SaleModel } from "../models/sale.model";


@Injectable({
  providedIn: 'root'
})
export class SaleService{
  #httpClient = inject(HttpClient);

  #endPoint = `${environment.apiGustovRestaurant}sale/`;

  save$(data: SaleModel, destroyRef: DestroyRef)
  {
    return this.#httpClient.post<ApiResponseInterface<boolean>>(this.#endPoint, data)
    .pipe(takeUntilDestroyed(destroyRef));
  }
}
