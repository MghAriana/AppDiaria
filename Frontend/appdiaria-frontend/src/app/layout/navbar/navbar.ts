import { Component, inject } from '@angular/core';
import { RouterLink, Router } from '@angular/router';

import { AuthService } from '../../core/services/authService';

@Component({
  selector: 'app-navbar',
  imports: [RouterLink],
  templateUrl: './navbar.html',
  styleUrl: './navbar.scss',
})
export class Navbar {
  private authService = inject(AuthService);
  private router = inject(Router);

  logout() {
    this.authService.logout();

    this.router.navigate(['/login']);
  }
}
