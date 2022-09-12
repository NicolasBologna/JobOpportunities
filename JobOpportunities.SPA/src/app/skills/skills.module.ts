import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SkillsRoutingModule } from './skills-routing.module';
import { SkillDetailsComponent } from './skill-details/skill-details.component';
import { SkillListComponent } from './skill-list/skill-list.component';


@NgModule({
  declarations: [
    SkillDetailsComponent,
    SkillListComponent
  ],
  imports: [
    CommonModule,
    SkillsRoutingModule
  ]
})
export class SkillsModule { }
