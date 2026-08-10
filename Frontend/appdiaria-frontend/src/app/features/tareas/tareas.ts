import { Component, OnInit, signal, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TareaService } from '../../core/services/tareaService';
import { Tarea } from '../../core/models/tarea';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-tareas',
  imports: [CommonModule,FormsModule],
  templateUrl: './tareas.html',
  styleUrl: './tareas.scss',
})
export class Tareas implements OnInit {

  protected tareas = signal<Tarea[]>([]);
  nombre = '';
  descripcion = '';
  fechaInicio = '';
  fechaFin = '';

  protected tareaService = inject(TareaService);

  public ngOnInit(): void {

    console.log("Entró al componente tareas");
    this.listarTareas();
  }


  public listarTareas(){

    console.log("Ejecutando listar tareas");

    this.tareaService.listar()
      .subscribe({

        next:(datos)=>{

          console.log("RESPUESTA API:", datos);

          this.tareas.set(datos);
        },

        error:(error)=>{

          console.error("ERROR API:", error);

        }

      });

  }


crearTarea(){

  const nuevaTarea = {

    nombre: this.nombre,
    descripcion: this.descripcion,
    fecha: this.fechaInicio,
    fin: this.fechaFin

  };


  this.tareaService.crear(nuevaTarea)
    .subscribe({

      next:()=>{

        console.log("Tarea creada");

        alert("Tarea creada correctamente");

        this.nombre = '';
        this.descripcion = '';
        this.fechaInicio = '';
        this.fechaFin = '';

        this.listarTareas();

      },

      error:(error)=>{

        console.error(error);

        alert("Error al crear tarea");

      }

    });

}
  
}

