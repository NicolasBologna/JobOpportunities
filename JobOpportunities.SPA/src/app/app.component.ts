import { Component, HostBinding } from '@angular/core';
import { FormControl } from '@angular/forms';

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

  themeToggleControl = new FormControl(false);

  @HostBinding('class') className = '';

  ngOnInit(): void {
    this.themeToggleControl.valueChanges.subscribe((val) => {
      this.className = val ? 'darkMode' : '';
    });
  }

  constructor() {}
}
