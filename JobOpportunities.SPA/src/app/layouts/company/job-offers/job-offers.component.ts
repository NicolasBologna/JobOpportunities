import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
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
  requiredSkills: new Array<Skill>(),
};

@Component({
  selector: 'app-job-offers',
  templateUrl: './job-offers.component.html',
  styleUrls: ['./job-offers.component.scss'],
})
export class JobOffersComponent implements OnInit {
  constructor(
    private repository: JobOffersRepositoryService,
    private toastr: ToastrService
  ) {}
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

  selectJobOffer(event: JobOffer) {
    this.selectedJobOffer = event;
  }
  saveJobOffer(event) {
    if (event.id) {
      this.repository.updateJobOffer('jobOffer', event).subscribe({
        next: () => {
          let idx = this.jobOffers.map((x) => x.id).indexOf(event.id);
          this.jobOffers[idx] = event;
          this.selectedJobOffer = null;
          this.toastr.success('La oferta se actualizó con éxito');
        },
        error: (err: HttpErrorResponse) => {},
      });
    } else {
      this.repository.createJobOffer('jobOffer', event).subscribe({
        next: (res: CreateJobResponseDto) => {
          this.jobOffers.push(res);
          this.selectedJobOffer = null;
          this.toastr.success('La oferta se creó con éxito');
        },
        error: (err: HttpErrorResponse) => {},
      });
    }
  }
  deleteJobOffer(event: string) {
    this.repository.delete(event).subscribe({
      next: () => {
        let idx = this.jobOffers.map((x) => x.id).indexOf(event);
        this.jobOffers.splice(idx, 1);
      },
      error: (err: HttpErrorResponse) => {},
    });
  }
  create(event) {
    this.selectedJobOffer = emptyjobOffer;
  }
  reset() {
    this.selectedJobOffer = null;
  }
}
