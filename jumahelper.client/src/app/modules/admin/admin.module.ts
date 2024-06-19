import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin.routing';
import { DuaTypesComponent } from './components/dua-types/dua-types.component';


@NgModule({
  declarations: [
    DuaTypesComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule
  ]
})
export class AdminModule { }
