import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { SkillLevel } from 'src/app/common/models/skill-level';
import { ErrorHandlerService } from 'src/app/common/services/error-handler.service';
import { SkillLevelsRepositoryService } from 'src/app/common/services/skill-levels-repository.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-skill-level-list',
  templateUrl: './skill-level-list.component.html',
  styleUrls: ['./skill-level-list.component.scss'],
})
export class SkillLevelListComponent implements OnInit {
  skillLevels: SkillLevel[];
  errorMessage: string = '';

  constructor(
    private repository: SkillLevelsRepositoryService,
    private errorHandler: ErrorHandlerService,
    private router: Router
  ) {}
  ngOnInit(): void {
    this.getAllOwners();
  }
  private getAllOwners = () => {
    const apiAddress: string = 'skillLevel';
    this.repository.getSkillLevels(apiAddress).subscribe({
      next: (skillLevels: SkillLevel[]) => (this.skillLevels = skillLevels),
      error: (err: HttpErrorResponse) => {
        this.errorHandler.handleError(err);
        this.errorMessage = this.errorHandler.errorMessage;
      },
    });
  };

  public getSkillLevelDetails = (id: string) => {
    const detailsUrl: string = `skill-levels/details/${id}`;
    this.router.navigate([detailsUrl]);
  };
}
