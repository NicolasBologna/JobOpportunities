import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CompanyLayoutRoutingModule } from './company-layout-routing.module';
import { CompanyLayoutComponent } from './company-layout.component';
import { HomeComponent } from './home/home.component';
import { MaterialModule } from 'src/app/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [CompanyLayoutComponent, HomeComponent],
  imports: [
    CommonModule,
    CompanyLayoutRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
  ],
})
export class CompanyLayoutModule {}
