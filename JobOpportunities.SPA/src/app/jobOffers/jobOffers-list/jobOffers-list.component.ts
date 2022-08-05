import { Component, Input, EventEmitter, OnInit, Output } from '@angular/core';
import { JobOffer } from 'src/app/common/models/jobOffer';

@Component({
  selector: 'app-jobOffers-list',
  templateUrl: './jobOffers-list.component.html',
  styleUrls: ['./jobOffers-list.component.scss'],
})
export class JobOffersListComponent {
  @Input() jobOffers: JobOffer[] = [];
  @Output() selected = new EventEmitter();
  @Output() deleted = new EventEmitter();
}
