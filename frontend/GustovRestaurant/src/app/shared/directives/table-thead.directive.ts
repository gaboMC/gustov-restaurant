import { Directive } from "@angular/core";

@Directive({
  selector: '[gustov-table-thead]',
  standalone: true,
  host:{
    class:
    'text-xs text-primary-900 uppercase bg-gray-100 border-b border-primary-800 dark:bg-gray-700 dark:text-custom-secondary-educen-500 dark:border-custom-secondary-educen-400',
  },
})

export class GustovTableTheadDirective {}
