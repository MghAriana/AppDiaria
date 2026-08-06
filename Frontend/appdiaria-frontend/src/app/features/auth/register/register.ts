import { RegisterRequest } from './../../../core/models/auth/registerRequest';
import { Component } from '@angular/core';
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

  nombre = '';
  email = '';
  password = '';

  constructor(
    private authService: AuthService,
    private router: Router
  ) { }

  registrar() {

    const usuario: RegisterRequest = {
      nombre: this.nombre,
      email: this.email,
      contraseña: this.password,
      fechaCreacion: new Date()
    };

    this.authService.register(usuario).subscribe({

      next: () => {

        console.log('Usuario registrado correctamente');

        alert('Usuario registrado correctamente');

        this.router.navigate(['/login']);

      },

     /* error: (error) => {

        console.error(error);

        alert('Ocurrió un error al registrar el usuario');

      }*/

    });

  }
  }


