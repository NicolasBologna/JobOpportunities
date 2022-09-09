import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { JobOffersRoutingModule } from './job-offers-routing.module';
import { JobOffersComponent } from './job-offers.component';
import { JobOffersListComponent } from './job-offers-list/job-offers-list.component';
import { JobOfferDetailsComponent } from './job-offer-details/job-offer-details.component';
import { MaterialModule } from '../material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    JobOffersComponent,
    JobOffersListComponent,
    JobOfferDetailsComponent,
  ],
  imports: [
    CommonModule,
    JobOffersRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
  ]
})
export class JobOffersModule { }
