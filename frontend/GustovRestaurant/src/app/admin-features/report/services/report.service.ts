import { HttpClient } from "@angular/common/http";
import { DestroyRef, inject, Injectable } from "@angular/core";
import { environment } from "../../../../environments/environment.development";
import { ApiResponseInterface } from "@gustov/core/models";
import { takeUntilDestroyed } from "@angular/core/rxjs-interop";
import { SalesHistory } from "../models/sales-history.model";

@Injectable({
  providedIn: 'root'
})
export class ReportService {
  #httpClient = inject(HttpClient);

  #endPoint = `${environment.apiGustovRestaurant}report`;

  printSalesDaily$(sales: SalesHistory[], destroyRef: DestroyRef) {
    const objectToSend = JSON.stringify(sales);
    return this.#httpClient.post<ApiResponseInterface<SalesHistory>>(`${this.#endPoint}printSalesDaily/`, objectToSend, {
      responseType: 'arraybuffer' as 'json'
    }).pipe(takeUntilDestroyed(destroyRef));
  }
}
