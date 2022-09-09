import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SkillLevelDetailsComponent } from './skill-level-details/skill-level-details.component';
import { SkillLevelListComponent } from './skill-level-list/skill-level-list.component';

const routes: Routes = [
  { path: '', component: SkillLevelListComponent },
  { path: 'details/:id', component: SkillLevelDetailsComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SkillLevelsRoutingModule {}
