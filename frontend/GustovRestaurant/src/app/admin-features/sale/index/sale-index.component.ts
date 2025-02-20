import { Component } from '@angular/core';
import { SvgIconComponent } from 'angular-svg-icon';
import { GustovTableTheadDirective } from '../../../shared/directives/table-thead.directive';
import { GustovTableBodyDirective } from '../../../shared/directives/table-body.directive';
import { GustovInputDirective } from '../../../shared/directives/input.directive';
import { GustovPrimaryButtonDirective } from '../../../shared/directives/primary-button.directive';

@Component({
  selector: 'app-sale-index',
  standalone: true,
  imports: [SvgIconComponent,
            GustovTableTheadDirective,
            GustovTableBodyDirective,
            GustovInputDirective,
            GustovPrimaryButtonDirective
  ],
  templateUrl: './sale-index.component.html',
  styleUrl: './sale-index.component.scss'
})
export class SaleIndexComponent {

}
