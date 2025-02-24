import { HttpClient } from "@angular/common/http";
import { DestroyRef, inject, Injectable } from "@angular/core";
import { environment } from "../../../environments/environment.development";
import { DishInterface } from "../models/dish.interface";
import { ApiResponseInterface } from "@gustov/core/models";
import { takeUntilDestroyed } from "@angular/core/rxjs-interop";

@Injectable({
  providedIn: 'root'
})
export class DishService{
  #httpClient = inject(HttpClient);

  #endPoint = `${environment.apiGustovRestaurant}dish/`;

  save$(data: DishInterface, dishId: number | null, destroyRef: DestroyRef)
  {
    console.log("hola", data);

    if (!dishId)
      return this.#httpClient.post<ApiResponseInterface<boolean>>(this.#endPoint, data)
      .pipe(takeUntilDestroyed(destroyRef));
    else
    return this.#httpClient.put<ApiResponseInterface<boolean>>(`${this.#endPoint}${dishId}`, data)
    .pipe(takeUntilDestroyed(destroyRef));
  }


  deleteSoft$(dishId: number, destroyRef: DestroyRef)
  {
    return this.#httpClient.patch<ApiResponseInterface<boolean>>(`${this.#endPoint}${dishId}`, {})
    .pipe(takeUntilDestroyed(destroyRef));
  }

  getAll$()
  {
    return this.#httpClient.get<ApiResponseInterface<Array<DishInterface>>>(this.#endPoint);
  }

  getById$(dishId: number)
  {
    return this.#httpClient.get<ApiResponseInterface<DishInterface>>(`${this.#endPoint}by-id/${dishId}`);
  }
}
