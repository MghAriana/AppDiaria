export interface EntrenamientoRutina {
  rutinaId: number;
  nombreRutina: string;
}

export interface Entrenamiento {
  id: number;
  nombre: string;
  fecha: string;
  rutinas: EntrenamientoRutina[];
  usuarioId: number;
}
