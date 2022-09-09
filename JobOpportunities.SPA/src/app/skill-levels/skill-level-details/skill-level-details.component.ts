import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SkillLevel } from 'src/app/common/models/skill-level';
import { ErrorHandlerService } from 'src/app/common/services/error-handler.service';
import { SkillLevelsRepositoryService } from 'src/app/common/services/skill-levels-repository.service';

@Component({
  selector: 'app-skill-level-details',
  templateUrl: './skill-level-details.component.html',
  styleUrls: ['./skill-level-details.component.scss'],
})
export class SkillLevelDetailsComponent implements OnInit {
  skillLevel: SkillLevel;
  errorMessage: string = '';
  constructor(
    private repository: SkillLevelsRepositoryService,
    private router: Router,
    private activeRoute: ActivatedRoute,
    private errorHandler: ErrorHandlerService
  ) {}
  ngOnInit() {
    this.getSkillLevelDetails();
  }
  getSkillLevelDetails = () => {
    const id: string = this.activeRoute.snapshot.params['id'];
    const apiUrl: string = `skillLevel/${id}`;
    this.repository.getSkillLevel(apiUrl).subscribe({
      next: (sk: SkillLevel) => (this.skillLevel = sk),
      error: (err: HttpErrorResponse) => {
        this.errorHandler.handleError(err);
        this.errorMessage = this.errorHandler.errorMessage;
      },
    });
  };
}
