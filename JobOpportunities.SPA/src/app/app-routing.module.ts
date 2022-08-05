import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { JobOffersComponent } from './jobOffers/jobOffers.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'jobOffers', component: JobOffersComponent },
  { path: '**', redirectTo: '/home' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
