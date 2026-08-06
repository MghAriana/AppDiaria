import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Tarea } from '../models/tarea'; 

@Injectable({
  providedIn: 'root'
})
export class TareaService {

  private http = inject(HttpClient);

  private apiUrl = environment.apiUrl;


  listar() {

    return this.http.get<Tarea[]>(
      `${this.apiUrl}/Tarea`
    );

  }
  crear(tarea: any) {
    return this.http.post(
      `${this.apiUrl}/Tarea`,
      tarea
    );
  }

}