import { RegisterRequest } from './../../../core/models/auth/registerRequest';
import { Component, inject, signal } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../../core/services/authService';
import { form, required, FormField, minLength } from '@angular/forms/signals';

@Component({
  selector: 'app-register',
  imports: [FormField],
  templateUrl: './register.html',
  styleUrl: './register.scss',
})
export class Register {
  private authService = inject(AuthService);
  private router = inject(Router);

  usuario: RegisterRequest = {
      nombre: '',
      email: '',
      password: '',
    }; 
    
  protected registrationModel = signal<RegisterRequest>(this.usuario);

  protected registrationForm = form(this.registrationModel, (schemaPath) => {
    required(schemaPath.nombre, {message: 'Username is required'});
    minLength(schemaPath.nombre, 3, {message: 'Username must be at least 3 characters long'});
    required(schemaPath.email, {message: 'Email is required'});
    required(schemaPath.password, {message: 'Password is required'});
  });

  errorMensaje = signal('');
  enviando = signal(false);

  registrar() {
    if (this.enviando()) return;

    this.enviando.set(true);
    this.errorMensaje.set('');

    this.authService.register(this.registrationModel())
    .subscribe({
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
