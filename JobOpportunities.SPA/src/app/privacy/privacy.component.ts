import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../common/services/authentication.service';

interface Claim {
  type: string;
  value: string;
}

@Component({
  selector: 'app-privacy',
  templateUrl: './privacy.component.html',
  styleUrls: ['./privacy.component.scss'],
})
export class PrivacyComponent implements OnInit {
  public claims: Claim[] = [];
  constructor(private _repository: AuthenticationService) {}
  ngOnInit(): void {
    this.getClaims();
  }
  public getClaims = () => {
    this._repository.getClaims('Auth/Claims').subscribe((res) => {
      console.log(res);

      this.claims = res['claims'] as [];
    });
  };
}
