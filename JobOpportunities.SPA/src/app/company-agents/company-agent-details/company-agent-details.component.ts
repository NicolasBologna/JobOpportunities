import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CompanyAgent } from 'src/app/common/models/company-agent';
import { JobOffer } from 'src/app/common/models/job-offer';
import { CompanyAgentsRepositoryService } from 'src/app/common/services/company-agents-repository.service';
import { ErrorHandlerService } from 'src/app/common/services/error-handler.service';

@Component({
  selector: 'app-company-agent-details',
  templateUrl: './company-agent-details.component.html',
  styleUrls: ['./company-agent-details.component.scss'],
})
export class CompanyAgentDetailsComponent implements OnInit {
  companyAgent: CompanyAgent;
  errorMessage: string = '';
  constructor(
    private repository: CompanyAgentsRepositoryService,
    private router: Router,
    private activeRoute: ActivatedRoute,
    private errorHandler: ErrorHandlerService
  ) {}
  ngOnInit() {
    this.getCompanyAgentDetails();
  }
  getCompanyAgentDetails = () => {
    const id: string = this.activeRoute.snapshot.params['id'];
    const apiUrl: string = `companyAgent/${id}`;
    this.repository.getCompanyAgent(apiUrl).subscribe({
      next: (sk: CompanyAgent) => (this.companyAgent = sk),
      error: (err: HttpErrorResponse) => {
        this.errorHandler.handleError(err);
        this.errorMessage = this.errorHandler.errorMessage;
      },
    });
  };

  printToConsole = (param: JobOffer) => {
    console.log('JobOffer parameter from the child component', param);
  };
}
