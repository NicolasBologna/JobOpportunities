import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Subject } from 'rxjs';
import { UserForAuthenticationDto } from '../models/user/user-for-authentication-dto';
import { UserForRegistrationDto } from '../models/user/user-for-registration';
import { AuthResponseDto } from '../responses/auth-response-dto';
import { RegistrationResponseDto } from '../responses/registration-response';
import { EnvironmentUrlService } from './environment-url.service';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService {
  constructor(
    private http: HttpClient,
    private envUrl: EnvironmentUrlService,
    private jwtHelper: JwtHelperService
  ) {}

  private authChangeSub = new Subject<boolean>();
  public authChanged = this.authChangeSub.asObservable();

  public sendAuthStateChangeNotification = (isAuthenticated: boolean) => {
    this.authChangeSub.next(isAuthenticated);
  };

  public registerUser = (route: string, body: UserForRegistrationDto) => {
    return this.http.post<RegistrationResponseDto>(
      this.createCompleteRoute(route, this.envUrl.urlAddress),
      body
    );
  };

  public loginUser = (route: string, body: UserForAuthenticationDto) => {
    return this.http.post<AuthResponseDto>(
      this.createCompleteRoute(route, this.envUrl.urlAddress),
      body
    );
  };

  public logout = () => {
    localStorage.removeItem('token');
    this.sendAuthStateChangeNotification(false);
  };

  public isUserAuthenticated = (): boolean => {
    const token = localStorage.getItem('token');
    console.log(token);
    return (
      token && token !== 'undefined' && !this.jwtHelper.isTokenExpired(token)
    );
  };

  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  };

  public getClaims = (route: string) => {
    return this.http.get(
      this.createCompleteRoute(route, this.envUrl.urlAddress)
    );
  };

  public isUserAdmin = (): boolean => {
    const token = localStorage.getItem('token');
    const decodedToken = this.jwtHelper.decodeToken(token);
    const role =
      decodedToken[
        'http://schemas.microsoft.com/ws/2008/06/identity/claims/role'
      ];
    return role === 'Admin';
  };
}
