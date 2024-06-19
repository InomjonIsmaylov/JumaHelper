import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DuaTypesComponent } from './components/dua-types/dua-types.component';

const routes: Routes = [
  {
    path: '', component: DuaTypesComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
