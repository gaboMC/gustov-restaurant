import { Directive } from "@angular/core";

@Directive({
  selector: '[gustov-secondary-button]',
  standalone: true,
  host:{
    class:
    'w-full md:w-auto flex items-center justify-center py-2 px-4 text-sm font-medium text-gray-900 focus:outline-none bg-white rounded-lg border border-gray-200 hover:bg-gray-100 hover:text-primary-700 focus:z-10 focus:ring-2 focus:ring-gray-200 dark:focus:ring-custom-secondary-educen-500 dark:bg-gray-800 dark:text-gray-400 dark:border-gray-600 dark:hover:text-white dark:hover:bg-custom-secondary-educen-600',
  },
})

export class GustovSecondaryButtonDirective {}
