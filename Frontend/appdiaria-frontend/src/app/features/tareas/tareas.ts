import { Component, signal, inject } from '@angular/core';
import { httpResource } from '@angular/common/http';
import { DatePipe } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { TareaService } from '../../core/services/tareaService';
import { Tarea } from '../../core/models/tarea';
import { CrearTareaRequest } from '../../core/models/crear-tarea-request';
import { environment } from '../../../environments/environment';
import { ActualizarTareaRequest } from '../../core/models/actualizar-tarea-request';

@Component({
  selector: 'app-tareas',
  imports: [FormsModule, DatePipe],
  templateUrl: './tareas.html',
  styleUrl: './tareas.scss',
})
export class Tareas {
  private tareaService = inject(TareaService);

  protected tareasResource = httpResource<Tarea[]>(() => `${environment.apiUrl}/Tarea`);

  nombre = signal('');
  descripcion = signal('');
  fechaInicio = signal('');
  fechaFin = signal('');

  guardando = signal(false);
  eliminando = signal(false);
  tareaEditandoId = signal<number | null>(null);
  mensaje = signal('');
  errorMensaje = signal('');

  crearTarea() {

    if (this.guardando()) return;

    this.guardando.set(true);
    this.errorMensaje.set('');

    const nuevaTarea: CrearTareaRequest = {
      nombre: this.nombre(),
      descripcion: this.descripcion(),
      fecha: this.fechaInicio(),
      fin: this.fechaFin(),
    };

    this.tareaService
      .crear(nuevaTarea)
      .subscribe({
        next: () => {
          this.guardando.set(false);
          this.nombre.set('');
          this.descripcion.set('');
          this.fechaInicio.set('');
          this.fechaFin.set('');
          this.mensaje.set('Tarea creada correctamente');
          this.tareasResource.reload();
        },
        error: () => {
          this.guardando.set(false);
          this.errorMensaje.set('No se pudo crear la tarea. Inténtalo nuevamente.');
        },
      });
  }

  limpiarMensaje() {
    this.mensaje.set('');
  }

  eliminarTarea(id: number) {

  if (this.eliminando()) return;

  const confirmar = confirm(
    '¿Estás seguro de que quieres eliminar esta tarea?'
  );

  if (!confirmar) return;

  this.eliminando.set(true);
  this.errorMensaje.set('');

  this.tareaService.eliminar(id).subscribe({
    next: () => {
      this.eliminando.set(false);

      this.mensaje.set('Tarea eliminada correctamente');

      this.tareasResource.reload(); //vuelve a hacer el get
    },

    error: () => {
      this.eliminando.set(false);

      this.errorMensaje.set(
        'No se pudo eliminar la tarea.'
      );
    },
  });
}

  editarTarea(tarea: Tarea) {

    this.tareaEditandoId.set(tarea.id);

    this.nombre.set(tarea.nombre);
    this.descripcion.set(tarea.descripcion);

    this.fechaInicio.set(
      this.formatearFechaParaInput(tarea.fechaInicio)
    );

    this.fechaFin.set(
      this.formatearFechaParaInput(tarea.fechaFin)
    );
  }

  private formatearFechaParaInput(fecha: Date): string {

    const date = new Date(fecha);

    const year = date.getFullYear();
    const month = String(date.getMonth() + 1).padStart(2, '0');
    const day = String(date.getDate()).padStart(2, '0');
    const hours = String(date.getHours()).padStart(2, '0');
    const minutes = String(date.getMinutes()).padStart(2, '0');

    return `${year}-${month}-${day}T${hours}:${minutes}`;
  }

  guardarTarea() {

    if (this.tareaEditandoId() !== null) {
      this.actualizarTarea();
    } else {
      this.crearTarea();
    }

  }
    /*
guardarTarea() {

  console.log('ID editando:', this.tareaEditandoId());

  if (this.tareaEditandoId() !== null) {
    console.log('Voy a EDITAR');
    this.actualizarTarea();
  } else {
    console.log('Voy a CREAR');
    this.crearTarea();
  }

}*/

  actualizarTarea() {

    const id = this.tareaEditandoId();

    if (id === null) return;
  
    this.guardando.set(true);
    this.errorMensaje.set('');

    const tarea: ActualizarTareaRequest = {
      
      nombre: this.nombre(),
      descripcion: this.descripcion(),
      fechaInicio: this.fechaInicio(),
      fechaFin: this.fechaFin(),
    };

    this.tareaService.editar(id, tarea).subscribe({

      next: () => {

        this.guardando.set(false);

        this.tareaEditandoId.set(null);

        this.nombre.set('');
        this.descripcion.set('');
        this.fechaInicio.set('');
        this.fechaFin.set('');

        this.mensaje.set(
          'Tarea modificada correctamente'
        );

        this.tareasResource.reload();
      },

      error: () => {

        this.guardando.set(false);
        this.errorMensaje.set(
          'No se pudo modificar la tarea.'
        );

      }

    });
  }
  
}
