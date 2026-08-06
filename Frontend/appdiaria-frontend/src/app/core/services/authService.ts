import { Injectable,inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { LoginRequest } from '../models/auth/loginRequest';
import { LoginResponse } from '../models/auth/loginResponse';
import { RegisterRequest } from '../models/auth/registerRequest';
@Injectable({
  providedIn: 'root'
})

export class AuthService {
   private http = inject(HttpClient);

   private apiUrl = environment.apiUrl;

  login(datos: LoginRequest) {
    return this.http.post<LoginResponse>(
      `${this.apiUrl}/Auth/login`,
      datos
    );
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
  return this.http.post(
    `${this.apiUrl}/Usuario`,
    datos
  );
}

   
}