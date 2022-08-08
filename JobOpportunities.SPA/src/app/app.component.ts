import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'Job Opportunities';
  links = [
    { path: '/home', icon: 'home', title: 'Home' },
    { path: '/jobOffers', icon: 'view_list', title: 'Job Offers' },
  ];

  constructor() {}
}
