import { Directive } from "@angular/core";

@Directive({
  selector: '[gustov-primary-button]',
  standalone: true,
  host:{
    class:
    'flex items-center justify-center text-white bg-primary-900 hover:bg-primary-800 focus:ring-2 focus:ring-primary-300 font-medium rounded-lg text-sm px-4 py-2 dark:bg-custom-secondary-educen-500 dark:hover:bg-custom-secondary-educen-600 focus:outline-none dark:focus:ring-custom-secondary-educen-500',
  },
})

export class GustovPrimaryButtonDirective {}
