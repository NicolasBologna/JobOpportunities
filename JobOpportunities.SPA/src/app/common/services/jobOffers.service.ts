import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { JobOffer } from '../models/jobOffer';

const BASE_URL = 'https://localhost:7278/api';

@Injectable({
  providedIn: 'root',
})
export class JobOffersService {
  model = 'joboffer';
  constructor(private http: HttpClient) {}

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
