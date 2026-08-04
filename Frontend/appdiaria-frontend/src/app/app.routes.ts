import { Routes } from '@angular/router';
import { Home } from './features/home/home';
import { MainLayout } from './layout/main-layout/main-layout';
import { Dashboard } from './features/dashboard/dashboard';
import { Login} from './features/auth/login/login';
import { Register } from './features/auth/register/register';
import { Tareas } from './features/tareas/tareas';
import { Recordatorios } from './features/recordatorios/recordatorios';
import { Rutinas } from './features/rutinas/rutinas';
import { Perfil } from './features/perfil/perfil';
import { Entrenamientos } from './features/entrenamientos/entrenamientos';

export const routes: Routes = [
  //publicas
  {
    path: '',
    component: Home
  },
   {
    path: 'login',
    component: Login
  },
  {
    path: 'registro',
    component: Register
  }
  ,
  //privadas
  {
    path: 'app',
    component: MainLayout,
    children: [
      {
        path: '',
        redirectTo: 'dashboard',
        pathMatch: 'full'
      },
      {
        path: 'dashboard',
        component: Dashboard
      },
      {
        path: 'tareas',
        component: Tareas
      },
            {
        path: 'entrenamientos',
        component: Entrenamientos
      },
      {
        path: 'rutinas',
        component: Rutinas
      },
      {
        path: 'recordatorios',
        component: Recordatorios
      },
      {
        path: 'perfil',
        component: Perfil
      },

    ]
  },
  {
    path: '**',
    redirectTo: ''
  }
];
