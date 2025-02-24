import { Component } from '@angular/core';
import { NavbarComponent } from '../../controls/navbar/navbar.component';
import { SidebarComponent } from '../../controls/sidebar/sidebar.component';

@Component({
  selector: 'app-main-dashboard',
  standalone: true,
  imports: [NavbarComponent,SidebarComponent],
  templateUrl: './main-dashboard.component.html',
  styleUrl: './main-dashboard.component.scss'
})
export class MainDashboardComponent {

}
