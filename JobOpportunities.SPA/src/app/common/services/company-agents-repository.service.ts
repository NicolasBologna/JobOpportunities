import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JobOffer } from '../models/job-offer';
import { EnvironmentUrlService } from './environment-url.service';

@Injectable({
  providedIn: 'root',
})
export class CompanyAgentsRepositoryService {
  constructor(
    private http: HttpClient,
    private envUrl: EnvironmentUrlService
  ) {}

  public getJobOffers = (route: string) => {
    return this.http.get<JobOffer[]>(
      this.createCompleteRoute(route, this.envUrl.urlAddress)
    );
  };
  public createJobOffer = (route: string, jobOffer: JobOffer) => {
    return this.http.post<JobOffer>(
      this.createCompleteRoute(route, this.envUrl.urlAddress),
      jobOffer,
      this.generateHeaders()
    );
  };
  public updateJobOffer = (route: string, jobOffer: JobOffer) => {
    return this.http.put(
      this.createCompleteRoute(route, this.envUrl.urlAddress),
      jobOffer,
      this.generateHeaders()
    );
  };
  public deleteJobOffer = (route: string) => {
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
