import { HttpClient } from "@angular/common/http";
import { DestroyRef, inject, Injectable } from "@angular/core";
import { environment } from "../../../../environments/environment.development";
import { SaleDetailInterface } from "../models/sale-detail.model";
import { takeUntilDestroyed } from "@angular/core/rxjs-interop";
import { ApiResponseInterface } from "@gustov/core/models";

@Injectable({
  providedIn: 'root'
})
export class SaleDetailService{
  #httpClient = inject(HttpClient);

  #endPoint = `${environment.apiGustovRestaurant}sale-detail/`;

  save$(data: SaleDetailInterface, destroyRef: DestroyRef)
  {
    return this.#httpClient.post<ApiResponseInterface<boolean>>(this.#endPoint, data)
    .pipe(takeUntilDestroyed(destroyRef));
  }

  delete$(saleDetailId: number, destroyRef: DestroyRef)
  {
    return this.#httpClient.delete<ApiResponseInterface<boolean>>(`${this.#endPoint}${saleDetailId}`)
    .pipe(takeUntilDestroyed(destroyRef));
  }

  getAll$()
  {
    return this.#httpClient.get<ApiResponseInterface<Array<SaleDetailInterface>>>(this.#endPoint);
  }
}
