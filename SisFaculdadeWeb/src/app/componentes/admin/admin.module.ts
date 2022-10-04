import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { AdminComponent } from 'src/app/componentes/admin/admin.component';
import { HomeAdminComponent } from './home-admin/home-admin.component';
import { FormsModule } from '@angular/forms';
import { SidenavComponent} from 'src/app/componentes/layout/sidenav/sidenav.component'
import { HeaderComponent } from 'src/app/componentes/layout/header/header.component';
import { SharedModule } from '../shared/shared.module';
import { BrowserModule } from '@angular/platform-browser';
import { AlunoService } from 'src/app/servicos/aluno.service';
import { ProfessorService } from 'src/app/servicos/professor.service';
import { CursoService } from 'src/app/servicos/curso.service';
import { DisciplinaService } from 'src/app/servicos/disciplina.service';
import { LocalStorageService } from 'src/app/servicos/local-storage.service';
import { CriarEditarCursoComponent } from './curso/criar-editar-curso/criar-editar-curso.component';
import { ListaCursosComponent } from './curso/lista-cursos/lista-cursos.component';
import { CriarEditarAlunoComponent } from './aluno/criar-editar-aluno/criar-editar-aluno.component';
import { ListaAlunosComponent } from './aluno/lista-alunos/lista-alunos.component';
import { ListaDisciplinasCursoComponent } from './curso/lista-disciplinas-cursos/lista-disciplinas-cursos.component';
import { ListaDisciplinasAlunoComponent } from './aluno/lista-disciplinas-aluno/lista-disciplinas-aluno.component';
import { ListaProfessoresComponent } from './professor/lista-professor/lista-professores.component';
import { CriarEditarProfessorComponent } from './professor/criar-editar-professor/criar-editar-professor.component';
import { ListaDisciplinasComponent } from './disciplina/lista-disciplinas/lista-disciplinas.component';
import { CriarEditarDisciplinaComponent } from './disciplina/criar-editar-disciplina/criar-editar-disciplina.component';

@NgModule({
  declarations: [AdminComponent, HomeAdminComponent,SidenavComponent,
    HeaderComponent
  ,CriarEditarCursoComponent
  ,ListaCursosComponent
  ,CriarEditarAlunoComponent
  ,ListaAlunosComponent
  ,ListaDisciplinasCursoComponent
  ,ListaDisciplinasAlunoComponent
  ,ListaProfessoresComponent
  ,CriarEditarProfessorComponent
  ,ListaDisciplinasComponent
  ,CriarEditarDisciplinaComponent
  ],
  imports: [
    CommonModule
    ,FormsModule
    ,AdminRoutingModule
    ,SharedModule
  ]
  ,exports: [
    SidenavComponent, HeaderComponent,SharedModule
  ]
  ,providers: [
    AlunoService, ProfessorService, CursoService, DisciplinaService, LocalStorageService
  ]
})
export class AdminModule { }
