import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SkillLevelsRoutingModule } from './skill-levels-routing.module';
import { SkillLevelListComponent } from './skill-level-list/skill-level-list.component';
import { SkillLevelDetailsComponent } from './skill-level-details/skill-level-details.component';


@NgModule({
  declarations: [SkillLevelListComponent, SkillLevelDetailsComponent],
  imports: [CommonModule, SkillLevelsRoutingModule],
})
export class SkillLevelsModule {}
