import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { JobOffer } from 'src/app/common/models/job-offer';

@Component({
  selector: 'app-company-agent-job-offers',
  templateUrl: './company-agent-job-offers.component.html',
  styleUrls: ['./company-agent-job-offers.component.scss'],
})
export class CompanyAgentJobOffersComponent implements OnInit {
  @Input() jobOffers: JobOffer[];
  @Output() onJobOfferClick: EventEmitter<JobOffer> = new EventEmitter();

  constructor() {}

  ngOnInit(): void {}

  onJobOfferClicked = (jobOffer: JobOffer) => {
    this.onJobOfferClick.emit(jobOffer);
  };
}
