import { Component, HostBinding } from '@angular/core';
import { UntypedFormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AuthenticationService } from './common/services/authentication.service';
import { StylesService } from './common/services/styles.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'Bolsa de Trabajo';

  public isUserAuthenticated: boolean;

  constructor(
    private authService: AuthenticationService,
    private router: Router,
    private styleService: StylesService
  ) {}
  links = [
    { path: '/home', icon: 'home', title: 'Home' },
    { path: '/job-offers', icon: 'view_list', title: 'Job Offers' },
    { path: '/skill-levels', icon: 'view_list', title: 'Skill Levels' },
    { path: '/company-agents', icon: 'view_list', title: 'Company Contacts' },
  ];

  @HostBinding('class') className = 'darkMode';

  ngOnInit(): void {
    this.styleService.darkModeChanged.subscribe((val) => {
      this.className = val ? 'darkMode' : '';
    });
    this.authService.authChanged.subscribe((res) => {
      this.isUserAuthenticated = res;
    });
    if (this.authService.isUserAuthenticated())
      this.authService.sendAuthStateChangeNotification(true);
  }

  public logout = () => {
    this.authService.logout();
    this.router.navigate(['/auth']);
  };
}
