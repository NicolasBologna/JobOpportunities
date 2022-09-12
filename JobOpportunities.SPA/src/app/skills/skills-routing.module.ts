import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SkillDetailsComponent } from './skill-details/skill-details.component';
import { SkillListComponent } from './skill-list/skill-list.component';

const routes: Routes = [
  { path: '', component: SkillListComponent },
  { path: 'details/:id', component: SkillDetailsComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SkillsRoutingModule {}
