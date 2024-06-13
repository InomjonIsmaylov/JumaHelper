import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DuaTypesComponent } from './modules/admin/components/dua-types/dua-types.component';

const routes: Routes = [
  {
    path: 'dua-types', component: DuaTypesComponent
  },
  {
    path: '**', redirectTo: 'dua-types'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
