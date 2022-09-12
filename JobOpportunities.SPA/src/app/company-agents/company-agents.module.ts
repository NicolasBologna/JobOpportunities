import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CompanyAgentsRoutingModule } from './company-agents-routing.module';
import { CompanyAgentsListComponent } from './company-agents-list/company-agents-list.component';
import { CompanyAgentDetailsComponent } from './company-agent-details/company-agent-details.component';


@NgModule({
  declarations: [
    CompanyAgentsListComponent,
    CompanyAgentDetailsComponent
  ],
  imports: [
    CommonModule,
    CompanyAgentsRoutingModule
  ]
})
export class CompanyAgentsModule { }
