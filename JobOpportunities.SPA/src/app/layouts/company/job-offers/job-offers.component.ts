import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { CreateJobResponseDto } from 'src/app/common/responses/create-job-response-dto';
import { JobOffer } from '../../../common/models/job-offer';
import { Skill } from '../../../common/models/skill';
import { JobOffersRepositoryService } from '../../../common/services/job-offers-repository.service';

const emptyjobOffer: JobOffer = {
  id: '',
  title: '',
  description: '',
  validUntil: '',
  companyId: '',
  requiredSkills: new Array<Skill>(),
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
  selectedJobOffer: JobOffer | null;

  ngOnInit(): void {
    this.getAllJobOffers();
  }
  private getAllJobOffers = () => {
    const apiAddress: string = 'companyAgent/jobOffer';
    this.repository.getJobOffers(apiAddress).subscribe((jobs) => {
      this.jobOffers = jobs;
    });
  };

  selectJobOffer(event) {}
  saveJobOffer(event) {
    this.repository.createJobOffer('jobOffer', event).subscribe({
      next: (res: CreateJobResponseDto) => {
        console.log(res);
        this.jobOffers.push(res);
      },
      error: (err: HttpErrorResponse) => {},
    });
  }
  deleteJobOffer(event) {}
  create(event) {
    this.selectedJobOffer = emptyjobOffer;
  }
  reset() {
    this.selectedJobOffer = null;
  }
}
