import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { JobOffer } from '../models/jobOffer';
import { EnvironmentUrlService } from './environmentUrl.service';

const BASE_URL = 'https://localhost:7278/api';

@Injectable({
  providedIn: 'root',
})
export class JobOffersRepositoryService {
  model = 'joboffer';
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

  all() {
    return this.http.get(this.getUrl);
  }

  find(id) {
    return this.http.get(this.getUrlWithID(id));
  }

  create(jobOffer: JobOffer) {
    return this.http.post(this.getUrl, jobOffer);
  }

  update(jobOffer: JobOffer) {
    return this.http.put(this.getUrlWithID(jobOffer.id), jobOffer);
  }

  delete(Id: string) {
    return this.http.delete(this.getUrlWithID(Id));
  }

  private get getUrl() {
    return `${BASE_URL}/${this.model}`;
  }

  private getUrlWithID(id) {
    return `${this.getUrl}/${id}`;
  }
}
