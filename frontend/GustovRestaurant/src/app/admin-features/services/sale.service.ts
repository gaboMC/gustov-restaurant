import { HttpClient } from "@angular/common/http";
import { DestroyRef, inject, Injectable } from "@angular/core";
import { ApiResponseInterface } from "@gustov/core/models";
import { takeUntilDestroyed } from "@angular/core/rxjs-interop";
import { environment } from "../../../environments/environment.development";
import { SaleInterface } from "../models";


@Injectable({
  providedIn: 'root'
})
export class SaleService{
  #httpClient = inject(HttpClient);

  #endPoint = `${environment.apiGustovRestaurant}sale/`;

  save$(data: SaleInterface, destroyRef: DestroyRef)
  {
    return this.#httpClient.post<ApiResponseInterface<boolean>>(this.#endPoint, data)
    .pipe(takeUntilDestroyed(destroyRef));
  }
}
