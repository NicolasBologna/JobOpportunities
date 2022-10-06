import { NgModule } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';

import { CompanyAgentsRoutingModule } from './company-agents-routing.module';
import { CompanyAgentsListComponent } from './company-agents-list/company-agents-list.component';
import { CompanyAgentDetailsComponent } from './company-agent-details/company-agent-details.component';
import { CompanyAgentJobOffersComponent } from './company-agent-details/company-agent-job-offers/company-agent-job-offers.component';
import { SharedModule } from '../shared/shared.module';
import { CompanyAgentCreateComponent } from './company-agent-create/company-agent-create.component';
import { ReactiveFormsModule } from '@angular/forms';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { MaterialModule } from '../material.module';

@NgModule({
  declarations: [
    CompanyAgentsListComponent,
    CompanyAgentDetailsComponent,
    CompanyAgentJobOffersComponent,
    CompanyAgentCreateComponent,
  ],
  imports: [
    CommonModule,
    CompanyAgentsRoutingModule,
    SharedModule,
    ReactiveFormsModule,
    BsDatepickerModule.forRoot(),
    MaterialModule,
  ],
  providers:[
    DatePipe
  ]
})
export class CompanyAgentsModule {}
