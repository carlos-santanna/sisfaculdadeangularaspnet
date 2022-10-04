import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './componentes/admin/admin.component';
const routes: Routes = [
  {
    path: 'admin',
    loadChildren: () => import('./componentes/admin/admin.module').then(m => m.AdminModule),
  }
  ,{
    path:'',
    redirectTo:'admin',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
