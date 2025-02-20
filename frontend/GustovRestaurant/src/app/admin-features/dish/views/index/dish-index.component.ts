import { Component, DestroyRef, inject } from '@angular/core';
import { SvgIconComponent } from 'angular-svg-icon';
import { GustovDialogComponent, GustovDialogService } from '../../../../shared/controls/dialog';
import { DishService } from '../../services/dish.service';
import { DishInterface } from '../../models/dish.interface';
import { map, of, switchMap } from 'rxjs';
import { ApiResponseInterface } from '@gustov/core/models';
import { DishFormComponent } from '../form/dish-form.component';
import { GustovPrimaryButtonDirective } from '../../../../shared/directives/primary-button.directive';
import { GustovInputDirective } from '../../../../shared/directives/input.directive';
import { GustovTableTheadDirective } from '../../../../shared/directives/table-thead.directive';
import { GustovTableBodyDirective } from '../../../../shared/directives/table-body.directive';

@Component({
  selector: 'app-index',
  standalone: true,
  imports: [SvgIconComponent,
            GustovPrimaryButtonDirective,
            GustovInputDirective,
            GustovTableTheadDirective,
            GustovTableBodyDirective
  ],
  templateUrl: './dish-index.component.html',
  styleUrl: './dish-index.component.scss'
})
export class DishIndexComponent {
  #dialogService = inject(GustovDialogService);
  #dishService = inject(DishService);
  #destroyRef = inject(DestroyRef);

  dishes = new Array<DishInterface>();

  constructor(){
    this.#showDishes$()
      .subscribe({
        next: (value) => {
          this.dishes = value;
        },
        error: (e) => console.log(e)
      })
  }

  openDishForm(dishId: number | null = null): void{
      this.#dialogService.open(DishFormComponent, {
        size: {
          width: 'auto',
          minWidth: '400px',
          maxWidth: '95%',
          height: 'auto',
          maxHeight: '80%'
        },
        data: dishId
      })
      .afterClosed()
      .pipe(
        switchMap((response: boolean) => {
          return response ? this.#showDishes$(): of(null)
        })
      ).subscribe({
        next: () => {
          console.log('Lista actualizada.');
        },
        error: (e) => console.error('Error al recargar los datos:', e)
      });
    }

    delete(dishId: number) {
      this.#dishService.delete$(dishId, this.#destroyRef)
        .pipe(
          switchMap((response) => {
            return this.#showDishes$();
          })
        )
        .subscribe({
          next: (value) => (this.dishes = value),
          error: (e) => console.log(e),
        });
    }

    #showDishes$() {
      return this.#dishService.getAll$()
        .pipe(
          map((value: ApiResponseInterface<Array<DishInterface>>) => {
            this.dishes = value.data;
            return this.dishes;
          })
        );
    }
}
