import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CompanyAgent } from '../models/company-agent';
import { EnvironmentUrlService } from './environment-url.service';

@Injectable({
  providedIn: 'root',
})
export class CompanyAgentsRepositoryService {
  constructor(
    private http: HttpClient,
    private envUrl: EnvironmentUrlService
  ) {}

  public getCompanyAgents = (route: string) => {
    return this.http.get<CompanyAgent[]>(
      this.createCompleteRoute(route, this.envUrl.urlAddress)
    );
  };
  public createCompanyAgent = (route: string, jobOffer: CompanyAgent) => {
    return this.http.post<CompanyAgent>(
      this.createCompleteRoute(route, this.envUrl.urlAddress),
      jobOffer,
      this.generateHeaders()
    );
  };
  public updateCompanyAgent = (route: string, jobOffer: CompanyAgent) => {
    return this.http.put(
      this.createCompleteRoute(route, this.envUrl.urlAddress),
      jobOffer,
      this.generateHeaders()
    );
  };
  public deleteCompanyAgent = (route: string) => {
    return this.http.delete(
      this.createCompleteRoute(route, this.envUrl.urlAddress)
    );
  };
  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  };
  private generateHeaders = () => {
    return {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    };
  };
}
