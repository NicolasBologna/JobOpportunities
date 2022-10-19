import { Component, HostBinding, OnInit } from '@angular/core';
import { UntypedFormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/common/services/authentication.service';

@Component({
  selector: 'app-company-layout',
  templateUrl: './company-layout.component.html',
  styleUrls: ['./company-layout.component.scss'],
})
export class CompanyLayoutComponent implements OnInit {
  title = 'Bolsa de Trabajo';

  public isUserAuthenticated: boolean;

  constructor(
    private authService: AuthenticationService,
    private router: Router
  ) {}
  links = [
    { path: '/home', icon: 'home', title: 'Home' },
    { path: '/job-offers', icon: 'view_list', title: 'Job Offers' },
    { path: '/skill-levels', icon: 'view_list', title: 'Skill Levels' },
    { path: '/company-agents', icon: 'view_list', title: 'Company Contacts' },
  ];

  themeToggleControl = new UntypedFormControl(true);

  @HostBinding('class') className = 'darkMode';

  ngOnInit(): void {
    this.themeToggleControl.valueChanges.subscribe((val) => {
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
