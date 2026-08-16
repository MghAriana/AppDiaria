
import { Component, inject, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../../core/services/authService';
import {LoginRequest} from '../../../core/models/auth/loginRequest';
import { form, required, FormField ,email} from '@angular/forms/signals';
@Component({
  selector: 'app-login',
  imports: [FormsModule, RouterLink, FormField],
  templateUrl: './login.html',
  styleUrl: './login.scss',
})
export class Login {
  private authService = inject(AuthService);
  private router = inject(Router);

  errorMensaje = signal('');
  enviando = signal(false);

  usuario: LoginRequest = {
        email: '',
        password: '',
      }; 

  protected loginModel = signal<LoginRequest>(this.usuario);

  protected loginForm = form(this.loginModel, (schemaPath) => {
    required(schemaPath.email, {message: 'Email is required'});
    email(schemaPath.email, {message: 'Email must be a valid email address'});
    required(schemaPath.password, {message: 'Password is required'});
  })


  login() {
    if (this.enviando()) return;

    this.enviando.set(true);
    this.errorMensaje.set('');


    this.authService
      .login(this.loginModel())
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
