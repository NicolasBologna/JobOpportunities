import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CompanyAgentDetailsComponent } from './company-agent-details/company-agent-details.component';
import { CompanyAgentsListComponent } from './company-agents-list/company-agents-list.component';

const routes: Routes = [
  { path: '', component: CompanyAgentsListComponent },
  { path: 'details/:id', component: CompanyAgentDetailsComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CompanyAgentsRoutingModule {}
