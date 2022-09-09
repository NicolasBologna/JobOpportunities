import { Component, HostBinding } from '@angular/core';
import { UntypedFormControl } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'Job Opportunities';
  links = [
    { path: '/home', icon: 'home', title: 'Home' },
    { path: '/job-offers', icon: 'view_list', title: 'Job Offers' },
    { path: '/skill-levels', icon: 'view_list', title: 'Skill levels' },
  ];

  themeToggleControl = new UntypedFormControl(false);

  @HostBinding('class') className = '';

  ngOnInit(): void {
    this.themeToggleControl.valueChanges.subscribe((val) => {
      this.className = val ? 'darkMode' : '';
    });
  }

  constructor() {}
}
