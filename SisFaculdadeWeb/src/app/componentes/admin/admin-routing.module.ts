import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin.component';
import { ListaAlunosComponent } from './aluno/lista-alunos/lista-alunos.component';
import { ListaCursosComponent } from './curso/lista-cursos/lista-cursos.component';
import { ListaDisciplinasComponent } from './disciplina/lista-disciplinas/lista-disciplinas.component';
import { HomeAdminComponent } from './home-admin/home-admin.component';
import { ListaProfessoresComponent } from './professor/lista-professor/lista-professores.component';

const routes: Routes = [
  {
    path: '',
    component: AdminComponent,
    children:[
      {
        path: 'home',
        component: HomeAdminComponent
      },
      {
        path: 'cursos',
        component: ListaCursosComponent
      },
      {
        path: 'alunos',
        component: ListaAlunosComponent
      },
      {
        path: 'professor',
        component: ListaProfessoresComponent
      },
      {
        path: 'disciplina',
        component: ListaDisciplinasComponent
      },
      {
        path: '',
        redirectTo: 'home',
        pathMatch: 'full'
      }

    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
