import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '', redirectTo: 'admin', pathMatch: 'full'
  },
  {
    path: 'admin', loadChildren: () => import('./modules/admin/admin.module').then(x => x.AdminModule)
  },
  {
    path: 'reader', loadChildren: () => import('./modules/reader/reader.module').then(x => x.ReaderModule)
  },
  {
    path: '**', redirectTo: 'admin'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
