import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SkillLevel } from '../models/skill-level';
import { EnvironmentUrlService } from './environment-url.service';

@Injectable({
  providedIn: 'root',
})
export class SkillLevelsRepositoryService {
  constructor(
    private http: HttpClient,
    private envUrl: EnvironmentUrlService
  ) {}

  public getSkillLevels = (route: string) => {
    return this.http.get<SkillLevel[]>(
      this.createCompleteRoute(route, this.envUrl.urlAddress)
    );
  };
  public getSkillLevel = (route: string) => {
    return this.http.get<SkillLevel>(
      this.createCompleteRoute(route, this.envUrl.urlAddress)
    );
  };
  public createSkillLevel = (route: string, skillLevel: SkillLevel) => {
    return this.http.post<SkillLevel>(
      this.createCompleteRoute(route, this.envUrl.urlAddress),
      skillLevel,
      this.generateHeaders()
    );
  };
  public updateSkillLevel = (route: string, skillLevel: SkillLevel) => {
    return this.http.put(
      this.createCompleteRoute(route, this.envUrl.urlAddress),
      skillLevel,
      this.generateHeaders()
    );
  };
  public deleteSkillLevel = (route: string) => {
    return this.http.delete(
      this.createCompleteRoute(route, this.envUrl.urlAddress)
    );
  };
  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  };
  private generateHeaders = () => {
    return {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    };
  };
}
