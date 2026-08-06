import { Component, OnInit,ChangeDetectorRef } from '@angular/core';
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

  tareas: Tarea[] = [];
  nombre = '';
  descripcion = '';
  fechaInicio = '';
  fechaFin = '';

  constructor(
    private tareaService: TareaService,
    private cd: ChangeDetectorRef
  ) {
     console.log("Constructor componente Tareas", this.tareas);
  }


  ngOnInit(): void {

    console.log("Entró al componente tareas");
    this.listarTareas();
  }
listarTareas(){

  console.log("Ejecutando listar tareas");

  this.tareaService.listar()
    .subscribe({

      next:(datos)=>{

        console.log("RESPUESTA API:", datos);

        this.tareas = datos;

        this.cd.detectChanges();

        console.log("Tareas en componente:", this.tareas);

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

