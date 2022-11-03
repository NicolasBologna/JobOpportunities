import { HttpErrorResponse } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AuthenticationService } from 'src/app/common/services/authentication.service';
import { UserForAuthenticationDto } from 'src/app/common/models/user/user-for-authentication-dto';
import { AuthResponseDto } from 'src/app/common/responses/auth-response-dto';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  private returnUrl: string;
  public showSpinner: boolean = false;

  loginForm: FormGroup;
  errorMessage: string = '';
  showError: boolean;
  constructor(
    private authService: AuthenticationService,
    private router: Router,
    private route: ActivatedRoute,
    private toastrSerive: ToastrService
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
    this.showSpinner = true;
    this.showError = false;
    const login = { ...loginFormValue };
    const userForAuth: UserForAuthenticationDto = {
      userName: login.username,
      password: login.password,
    };
    this.authService.loginUser('auth/token', userForAuth).subscribe({
      next: (res: AuthResponseDto) => {
        localStorage.setItem('token', res.accessToken);
        localStorage.setItem('user_type', this.authService.getUserRole());
        this.authService.sendAuthStateChangeNotification(res.isAuthSuccessful);
        this.toastrSerive.success('Ingresó correctamente', 'Bienvenido!');
        this.router.navigate([this.returnUrl]);
      },
      error: (err: HttpErrorResponse) => {
        this.errorMessage = err.message;
        this.toastrSerive.error('Hubo un error', 'Intente nuevamente');

        this.showError = true;
        this.showSpinner = false;
      },
    });
  };
}
