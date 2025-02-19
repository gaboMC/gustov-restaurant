import { Component } from '@angular/core';
import { RouteInfo } from '../../models/route-info.interface';
import { SvgIconComponent } from 'angular-svg-icon';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { CommonModule } from '@angular/common';
import { ROUTES } from '../../views/main-layout/main-layout.routes.config';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [SvgIconComponent,
            RouterLink,
            RouterLinkActive,
            CommonModule
  ],
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.scss'
})
export class SidebarComponent {

  menuItems : RouteInfo[] | null = [];
  constructor(){
    this.menuItems = ROUTES.filter(menuItem => menuItem);
  }
  submenuOpen: { [key: number]: boolean } = {};
}
