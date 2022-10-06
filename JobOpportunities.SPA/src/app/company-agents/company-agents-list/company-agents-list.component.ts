import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { CompanyAgent } from 'src/app/common/models/company-agent';
import { CompanyAgentsRepositoryService } from 'src/app/common/services/company-agents-repository.service';
import { ErrorHandlerService } from 'src/app/common/services/error-handler.service';

@Component({
  selector: 'app-company-agents-list',
  templateUrl: './company-agents-list.component.html',
  styleUrls: ['./company-agents-list.component.scss'],
})
export class CompanyAgentsListComponent implements OnInit {
  errorMessage: string = '';
  displayedColumns: string[] = [
    'id',
    'cuit',
    'userName',
    'email',
    'fullName',
    'details',
    'update',
    'delete',
  ];
  dataSource: MatTableDataSource<CompanyAgent> = new MatTableDataSource();

  constructor(
    private repository: CompanyAgentsRepositoryService,
    private errorHandler: ErrorHandlerService,
    private router: Router
  ) {}
  ngOnInit(): void {
    this.getAllCompanyAgents();
  }

  private getAllCompanyAgents = () => {
    const apiAddress: string = 'companyAgent';
    this.repository.getCompanyAgents(apiAddress).subscribe({
      next: (companyAgents: CompanyAgent[]) =>
        (this.dataSource = new MatTableDataSource(companyAgents)),
      error: (err: HttpErrorResponse) => {
        this.errorHandler.handleError(err);
        this.errorMessage = this.errorHandler.errorMessage;
      },
    });
  };

  public getCompanyAgentDetails = (id: string) => {
    const detailsUrl: string = `company-agents/details/${id}`;
    this.router.navigate([detailsUrl]);
  };

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
}
