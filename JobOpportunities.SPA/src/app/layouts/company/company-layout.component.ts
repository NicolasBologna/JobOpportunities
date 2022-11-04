import { Component, OnInit } from '@angular/core';
import { UntypedFormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/common/services/authentication.service';
import { StylesService } from 'src/app/common/services/styles.service';

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
    private router: Router,
    private styleService: StylesService
  ) {}
  links = [
    { path: '/home', icon: 'home', title: 'Inicio' },
    { path: '/job-offers', icon: 'view_list', title: 'Mis Ofertas' },
  ];

  themeToggleControl = new UntypedFormControl(true);

  ngOnInit(): void {
    this.themeToggleControl.valueChanges.subscribe((val) => {
      this.styleService.sendDarkModeChangeNotification(val ? 'darkMode' : '');
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
