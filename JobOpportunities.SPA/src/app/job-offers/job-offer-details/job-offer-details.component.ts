import { Component, EventEmitter, OnInit, Output, Input } from '@angular/core';
import { JobOffer } from 'src/app/common/models/job-offer';

@Component({
  selector: 'app-job-offer-details',
  templateUrl: './job-offer-details.component.html',
  styleUrls: ['./job-offer-details.component.scss'],
})
export class JobOfferDetailsComponent {
  currentJobOffer: JobOffer;
  originalTitle = '';

  @Output() saved = new EventEmitter();
  @Output() cancelled = new EventEmitter();
  @Input() set jobOffer(value) {
    if (!value) return;
    this.currentJobOffer = { ...value };
    this.originalTitle = value.title;
  }
}
