import { Component, signal, inject } from '@angular/core';
import { httpResource } from '@angular/common/http';
import { DatePipe } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { TareaService } from '../../core/services/tareaService';
import { Tarea } from '../../core/models/tarea';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-tareas',
  imports: [FormsModule, DatePipe],
  templateUrl: './tareas.html',
  styleUrl: './tareas.scss',
})
export class Tareas {
  private tareaService = inject(TareaService);

  protected tareasResource = httpResource<Tarea[]>(
    () => `${environment.apiUrl}/Tarea`
  );

  nombre = signal('');
  descripcion = signal('');
  fechaInicio = signal('');
  fechaFin = signal('');

  creando = signal(false);
  mensaje = signal('');
  errorMensaje = signal('');

  crearTarea() {
    if (this.creando()) return;

    this.creando.set(true);
    this.errorMensaje.set('');

    this.tareaService
      .crear({
        nombre: this.nombre(),
        descripcion: this.descripcion(),
        fecha: this.fechaInicio(),
        fin: this.fechaFin(),
      })
      .subscribe({
        next: () => {
          this.creando.set(false);
          this.nombre.set('');
          this.descripcion.set('');
          this.fechaInicio.set('');
          this.fechaFin.set('');
          this.mensaje.set('Tarea creada correctamente');
          this.tareasResource.reload();
        },
        error: () => {
          this.creando.set(false);
          this.errorMensaje.set('No se pudo crear la tarea. Inténtalo nuevamente.');
        },
      });
  }

  limpiarMensaje() {
    this.mensaje.set('');
  }
}
