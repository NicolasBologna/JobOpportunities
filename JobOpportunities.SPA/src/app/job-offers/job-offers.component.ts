import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { JobOffer } from '../common/models/job-offer';
import { JobOffersRepositoryService } from '../common/services/job-offers-repository.service';

const emptyjobOffer: JobOffer = {
  id: '',
  title: '',
  description: '',
  validUntil: '',
  companyId: '',
};

@Component({
  selector: 'app-job-offers',
  templateUrl: './job-offers.component.html',
  styleUrls: ['./job-offers.component.scss'],
})
export class JobOffersComponent implements OnInit {
  //1. render jobOffers in a list
  // 2. Select a jobOffer
  // 3. Render Selected jobOffer
  constructor(private repository: JobOffersRepositoryService) {}
  jobOffers: JobOffer[] = [];

  ngOnInit(): void {
    this.getAllJobOffers();
  }
  private getAllJobOffers = () => {
    const apiAddress: string = 'jobOffer';
    this.repository.getJobOffers(apiAddress).subscribe((own) => {
      this.jobOffers = own;
    });
  };

  selectJobOffer(event) {}
  deleteJobOffer(event) {}
}
