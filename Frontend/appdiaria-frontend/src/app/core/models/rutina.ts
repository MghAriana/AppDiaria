import { RutinaEjercicio } from './rutina-ejercicio';

export interface Rutina {
  id: number;
  nombre: string;
  dia: string;
  descripcion: string;
  ejercicios: RutinaEjercicio[];
  esPredeterminada: boolean;
}
