import { Component, EventEmitter, OnInit, Output, Input } from '@angular/core';
import { JobOffer } from 'src/app/common/models/jobOffer';

@Component({
  selector: 'app-jobOffer-details',
  templateUrl: './jobOffer-details.component.html',
  styleUrls: ['./jobOffer-details.component.scss'],
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
