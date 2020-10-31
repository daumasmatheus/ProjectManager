import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'account/login' },
  {
    path: 'account', 
    loadChildren: () => import('./components/account/account.module').then(m => m.AccountModule)
  },
  { 
    path: 'dashboard', 
    loadChildren: () => import('./components/dashboard/dashboard.module').then(m => m.DashboardModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
