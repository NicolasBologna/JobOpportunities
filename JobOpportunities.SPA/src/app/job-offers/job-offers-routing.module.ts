import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { JobOffersListComponent } from './job-offers-list/job-offers-list.component';
import { JobOffersComponent } from './job-offers.component';

const ROUTES: Routes = [
  {path: '', component: JobOffersComponent},
  {path: 'list', component: JobOffersListComponent}
];

@NgModule({
  imports: [RouterModule.forChild(ROUTES)],
  exports: [RouterModule]
})
export class JobOffersRoutingModule { }
