import { Component } from '@angular/core';
import { initFlowbite } from 'flowbite';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss'
})
export class NavbarComponent {
ngOnInit(): void {
    initFlowbite();
    document.documentElement.classList.add('dark');
    const checkbox = document.querySelector('input[name="dark-mode"]') as HTMLInputElement;
    if (checkbox) {
      checkbox.checked = true;
    }
  }
  toggleDarkMode(event: Event): void {
    const isChecked = (event.target as HTMLInputElement).checked;
    if (isChecked) {
      document.documentElement.classList.add('dark');
    } else {
      document.documentElement.classList.remove('dark');
    }
  }
}
