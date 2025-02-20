import { Component, DestroyRef, inject } from '@angular/core';
import { GustovDialogService } from '../../../../shared/controls/dialog';
import { DishService } from '../../services/dish.service';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { DishInterface } from '../../models/dish.interface';
import { ApiResponseInterface } from '@gustov/core/models';
import { GustovInputDirective } from '../../../../shared/directives/input.directive';
import { GustovPrimaryButtonDirective } from '../../../../shared/directives/primary-button.directive';
import { GustovSecondaryButtonDirective } from '../../../../shared/directives/secondary-button.directive';

@Component({
  selector: 'app-form',
  standalone: true,
  imports: [GustovInputDirective,
            GustovPrimaryButtonDirective,
            GustovSecondaryButtonDirective,
            ReactiveFormsModule
  ],
  templateUrl: './dish-form.component.html',
  styleUrl: './dish-form.component.scss'
})
export class DishFormComponent {
  #dialogService = inject(GustovDialogService);
  #dishService = inject(DishService);
  #destroyRef = inject(DestroyRef);

  dishId = this.#dialogService.dialogConfig?.data as number | null;
  formGroup!: FormGroup;

  constructor(){
    this.#initializeComponent();
    this.#loadData();
  }

  #initializeComponent(){
    this.formGroup = new FormGroup({
      id: new FormControl<number | null>(0),
      name: new FormControl<string | null>(null),
      description: new FormControl<string | null>(null),
      price: new FormControl<number | null>(null),
      isActive: new FormControl<boolean | null>(true)
    });
  }

  #loadData(){
    if (this.dishId && this.dishId > 0) {
      this.#dishService.getById$(this.dishId)
        .subscribe({
          next: (value: ApiResponseInterface<DishInterface>) => {
            console.log(value);
            this.formGroup.setValue({
              id: value.data.id,
              name: value.data.name,
              description: value.data.description,
              price: value.data.price,
              isActive: value.data.isActive
            });
          },
          error: (e) => console.log(e)
        });
        //console.log(this.dishId);

    }
  }

  onSubmit(){
    console.log(this.dishId);

    const request$ = this.dishId
    ? this.#dishService.update$(this.formGroup.value as DishInterface, this.#destroyRef)
    : this.#dishService.save$(this.formGroup.value as DishInterface, this.#destroyRef);


    request$.subscribe({
      next: (response: ApiResponseInterface<boolean>) => {
        if (response.isSuccess) {
          this.#dialogService.close(true);
        } else {
          console.log(response.errors);
        }
      },
      error: (e) => console.log(e)
    });
  }

  close(){
    this.#dialogService.close();
  }
}
