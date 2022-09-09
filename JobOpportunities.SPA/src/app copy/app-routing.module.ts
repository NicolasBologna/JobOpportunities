import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { JobOffersComponent } from './job-offers/job-offers.component';
import { HomeComponent } from './home/home.component';
import { NotFoundComponent } from './error-pages/not-found/not-found.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'job-offers', loadChildren: () => import('./job-offers/job-offers.module').then(m => m.JobOffersModule) },
  { path: '404', component: NotFoundComponent },
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: '**', redirectTo: '/404', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
