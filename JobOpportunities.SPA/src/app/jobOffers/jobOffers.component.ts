import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { JobOffer } from '../common/models/jobOffer';
import { JobOffersService } from '../common/services/jobOffers.service';

const emptyjobOffer: JobOffer = {
  id: '',
  title: '',
  description: '',
  validUntil: '',
  companyId: '',
};

@Component({
  selector: 'app-jobOffers',
  templateUrl: './jobOffers.component.html',
  styleUrls: ['./jobOffers.component.scss'],
})
export class JobOffersComponent implements OnInit {
  //1. render jobOffers in a list
  // 2. Select a jobOffer
  // 3. Render Selected jobOffer
  constructor(private jobOffersService: JobOffersService) {}

  jobOffers = [];
  jobOffers$: any; //Observable<jobOffer[]>;

  selectedJobOffer = { ...emptyjobOffer };
  originalTitle = '';

  ngOnInit(): void {
    this.fetchJobOffers();
  }

  fetchJobOffers() {
    this.jobOffers$ = this.jobOffersService.all();

    // this.jobOffersService
    //   .all()
    //   .subscribe((result: any) => (this.jobOffers = result));
  }

  selectJobOffer(jobOffer) {
    this.originalTitle = jobOffer.title;
    this.selectedJobOffer = jobOffer;
  }

  saveJobOffer(jobOffer) {
    console.log(jobOffer);
    if (jobOffer.id) {
      this.updateJobOffer(jobOffer);
    } else {
      this.createJobOffer(jobOffer);
    }
  }

  createJobOffer(jobOffer) {
    this.jobOffersService
      .create(jobOffer)
      .subscribe((result) => this.fetchJobOffers());
  }
  updateJobOffer(jobOffer) {
    this.jobOffersService
      .update(jobOffer)
      .subscribe((result) => this.fetchJobOffers());
  }

  deleteJobOffer(jobOfferId: number) {
    console.log('DELETE jobOffer', jobOfferId);
  }

  reset() {
    this.selectJobOffer({ ...emptyjobOffer });
  }
}
