import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Tarea } from '../models/tarea';
import { CrearTareaRequest } from '../models/crear-tarea-request';
import { ActualizarTareaRequest } from '../models/actualizar-tarea-request';

@Injectable({
  providedIn: 'root',
})
export class TareaService {
  private http = inject(HttpClient);

  private apiUrl = environment.apiUrl;

  listar() {
    return this.http.get<Tarea[]>(`${this.apiUrl}/Tarea`);
  }
  
  crear(tarea: CrearTareaRequest) {
    return this.http.post(`${this.apiUrl}/Tarea`, tarea);
  }

  eliminar(id: number) {
  return this.http.delete(`${this.apiUrl}/Tarea/${id}`);
  }

  editar(id: number, tarea: ActualizarTareaRequest) {
    return this.http.put(
      `${this.apiUrl}/Tarea/${id}`,
      tarea
    );
  }
}
