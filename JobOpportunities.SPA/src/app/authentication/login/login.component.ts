import { HttpErrorResponse } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AuthenticationService } from 'src/app/common/services/authentication.service';
import { UserForAuthenticationDto } from 'src/app/common/models/user/user-for-authentication-dto';
import { AuthResponseDto } from 'src/app/common/responses/auth-response-dto';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  private returnUrl: string;

  loginForm: FormGroup;
  errorMessage: string = '';
  showError: boolean;
  constructor(
    private authService: AuthenticationService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.loginForm = new FormGroup({
      username: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required]),
      userType: new FormControl('candidate'),
    });
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }
  validateControl = (controlName: string) => {
    return (
      this.loginForm.get(controlName).invalid &&
      this.loginForm.get(controlName).touched
    );
  };
  hasError = (controlName: string, errorName: string) => {
    return this.loginForm.get(controlName).hasError(errorName);
  };

  loginUser = (loginFormValue) => {
    this.showError = false;
    const login = { ...loginFormValue };
    const userForAuth: UserForAuthenticationDto = {
      userName: login.username,
      password: login.password,
      userType: login.userType,
    };
    console.log(userForAuth);
    this.authService.loginUser('auth/token', userForAuth).subscribe({
      next: (res: AuthResponseDto) => {
        localStorage.setItem('token', res.accessToken);
        this.authService.sendAuthStateChangeNotification(res.isAuthSuccessful);
        this.router.navigate([this.returnUrl]);
      },
      error: (err: HttpErrorResponse) => {
        this.errorMessage = err.message;
        this.showError = true;
      },
    });
  };
}
