import { Directive } from "@angular/core";

@Directive({
  selector: '[gustov-input]',
  standalone: true,
  host:{
    class:
    'bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-primary-500 focus:border-primary-500 block w-full pl-2 p-2 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-custom-secondary-gustov-500 dark:focus:border-custom-secondary-gustov-500',
  },
})
export class GustovInputDirective {}
