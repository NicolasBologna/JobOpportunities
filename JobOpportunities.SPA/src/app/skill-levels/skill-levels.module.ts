import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SkillLevelsRoutingModule } from './skill-levels-routing.module';
import { SkillLevelListComponent } from './skill-level-list/skill-level-list.component';


@NgModule({
  declarations: [
    SkillLevelListComponent
  ],
  imports: [
    CommonModule,
    SkillLevelsRoutingModule
  ]
})
export class SkillLevelsModule { }
