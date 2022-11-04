import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { JobOffersListComponent } from './job-offers-list/job-offers-list.component';
import { JobOfferDetailsComponent } from './job-offer-details/job-offer-details.component';
import { MaterialModule } from '../material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { JobOffersComponent } from './job-offers.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    JobOffersComponent,
    JobOffersListComponent,
    JobOfferDetailsComponent,
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([{ path: '', component: JobOffersComponent }]),
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
  ],
})
export class JobOffersModule {}
