import { Component, inject, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../../core/services/authService';

@Component({
  selector: 'app-login',
  imports: [FormsModule, RouterLink],
  templateUrl: './login.html',
  styleUrl: './login.scss',
})
export class Login {
  private authService = inject(AuthService);
  private router = inject(Router);

  email = signal('');
  password = signal('');
  enviando = signal(false);
  errorMensaje = signal('');

  login() {
    if (this.enviando()) return;

    this.enviando.set(true);
    this.errorMensaje.set('');

    this.authService
      .login({
        email: this.email(),
        contraseña: this.password(),
      })
      .subscribe({
        next: (respuesta) => {
          this.enviando.set(false);
          localStorage.setItem('token', respuesta.token);
          this.router.navigate(['/app/dashboard']);
        },
        error: () => {
          this.enviando.set(false);
          this.errorMensaje.set('Email o contraseña incorrectos.');
        },
      });
  }
}
