import { Directive } from "@angular/core";

@Directive({
  selector: '[gustov-table-body]',
  standalone: true,
  host:{
    class:'border-b border-primary-200 hover:bg-primary-50 dark:border-custom-secondary-educen-700 dark:hover:bg-custom-secondary-educen-700',
  },
})
export class GustovTableBodyDirective {}
