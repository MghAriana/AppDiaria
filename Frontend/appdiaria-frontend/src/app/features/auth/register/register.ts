import { RegisterRequest } from './../../../core/models/auth/registerRequest';
import { Component, inject, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../../core/services/authService';

@Component({
  selector: 'app-register',
  imports: [FormsModule],
  templateUrl: './register.html',
  styleUrl: './register.scss',
})
export class Register {
  private authService = inject(AuthService);
  private router = inject(Router);

  nombre = signal('');
  email = signal('');
  password = signal('');
  enviando = signal(false);
  errorMensaje = signal('');

  registrar() {
    if (this.enviando()) return;

    this.enviando.set(true);
    this.errorMensaje.set('');

    const usuario: RegisterRequest = {
      nombre: this.nombre(),
      email: this.email(),
      contraseña: this.password(),
      fechaCreacion: new Date(),
    };

    this.authService.register(usuario).subscribe({
      next: () => {
        this.enviando.set(false);
        this.router.navigate(['/login']);
      },
      error: () => {
        this.enviando.set(false);
        this.errorMensaje.set('Ocurrió un error al registrar el usuario.');
      },
    });
  }
}
