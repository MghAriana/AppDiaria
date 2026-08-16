import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { LoginRequest } from '../models/auth/loginRequest';
import { LoginResponse } from '../models/auth/loginResponse';
import { RegisterRequest } from '../models/auth/registerRequest';
@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private http = inject(HttpClient);

  private apiUrl = environment.apiUrl;

  login(datos: LoginRequest) {
    const body = {
      email: datos.email,
      contraseña: datos.password,
    };
    return this.http.post<LoginResponse>(`${this.apiUrl}/Auth/login`, body);
  }

  /*probemos
   testToken() {
    return this.http.get(
      `${this.apiUrl}/weatherforecast`
    );
  }*/
  logout() {
    localStorage.removeItem('token');
  }
  
  register(datos: RegisterRequest) {
    const body2 = {
      nombre: datos.nombre,
      email: datos.email,
      contraseña: datos.password,
    };
    return this.http.post(`${this.apiUrl}/Usuario`, body2);
  }
}
