import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SkillLevelListComponent } from './skill-level-list/skill-level-list.component';

const routes: Routes = [{ path: '', component: SkillLevelListComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SkillLevelsRoutingModule {}
