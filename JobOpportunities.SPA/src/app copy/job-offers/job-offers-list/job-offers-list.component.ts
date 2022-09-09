import { Component, Input, EventEmitter, OnInit, Output } from '@angular/core';
import { JobOffer } from 'src/app/common/models/job-offer';

@Component({
  selector: 'app-job-offers-list',
  templateUrl: './job-offers-list.component.html',
  styleUrls: ['./job-offers-list.component.scss'],
})
export class JobOffersListComponent {
  @Input() jobOffers: JobOffer[] = [];
  @Output() selected = new EventEmitter();
  @Output() deleted = new EventEmitter();
}
