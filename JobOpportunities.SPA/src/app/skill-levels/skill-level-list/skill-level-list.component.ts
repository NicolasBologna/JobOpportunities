import { Component, OnInit } from '@angular/core';
import { SkillLevel } from 'src/app/common/models/skill-level';
import { SkillLevelsRepositoryService } from 'src/app/common/services/skill-levels-repository.service';

@Component({
  selector: 'app-skill-level-list',
  templateUrl: './skill-level-list.component.html',
  styleUrls: ['./skill-level-list.component.scss'],
})
export class SkillLevelListComponent implements OnInit {
  skillLevels: SkillLevel[];
  constructor(private repository: SkillLevelsRepositoryService) {}
  ngOnInit(): void {
    this.getAllOwners();
  }
  private getAllOwners = () => {
    const apiAddress: string = 'skillLevel';
    this.repository.getSkillLevels(apiAddress).subscribe((response) => {
      this.skillLevels = response;
    });
  };
}
