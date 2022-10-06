import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserForRegistrationDto } from '../models/user/user-for-registration';
import { RegistrationResponseDto } from '../responses/registration-response';
import { EnvironmentUrlService } from './environment-url.service';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService {
  constructor(
    private http: HttpClient,
    private envUrl: EnvironmentUrlService
  ) {}
  public registerUser = (route: string, body: UserForRegistrationDto) => {
    return this.http.post<RegistrationResponseDto>(
      this.createCompleteRoute(route, this.envUrl.urlAddress),
      body
    );
  };
  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  };
}
