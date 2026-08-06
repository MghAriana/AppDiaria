import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router,RouterLink } from '@angular/router';
import { AuthService } from '../../../core/services/authService';

@Component({
  selector: 'app-login',
  imports: [FormsModule, RouterLink],
  templateUrl: './login.html',
  styleUrl: './login.scss',
})
export class Login {
  //servicios
  private authService = inject(AuthService);
  private router = inject(Router);
 //variables
  email = '';
  password = '';

  ////////////metodos//////
  login() {

  this.authService.login({
    email: this.email,
    contraseña: this.password
  }).subscribe({

    next: (respuesta) => {

    localStorage.setItem('token', respuesta.token);

    console.log('Login correcto');
    console.log(respuesta);

    this.router.navigate(['/app/dashboard']);

      
  },

    error: (error) => {

      console.error('Error al iniciar sesión');
      console.error(error);

    }

  });
  

}


}
