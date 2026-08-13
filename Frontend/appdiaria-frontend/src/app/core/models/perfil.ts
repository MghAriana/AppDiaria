import { Tarea } from './tarea';
import { Recordatorio } from './recordatorios';
import { Entrenamiento } from './entrenamiento';

export interface Perfil {
  id: number;
  nombre: string;
  email: string;
  fechaCreacion: Date;
  tareas: Tarea[];
  recordatorios: Recordatorio[];
  entrenamientos: Entrenamiento[];
}
