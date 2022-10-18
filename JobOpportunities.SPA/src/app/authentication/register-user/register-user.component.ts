import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { PasswordConfirmationValidatorService } from 'src/app/common/custom-validators/password-confirmation-validator.service';
import { UserForRegistrationDto } from 'src/app/common/models/user/user-for-registration';
import { AuthenticationService } from 'src/app/common/services/authentication.service';

@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.scss'],
})
export class RegisterUserComponent implements OnInit {
  public registerForm: FormGroup;
  public errorMessage: string = '';
  public showError: boolean;
  constructor(
    private authService: AuthenticationService,
    private passConfValidator: PasswordConfirmationValidatorService,
    private router: Router
  ) {}
  ngOnInit(): void {
    this.registerForm = new FormGroup({
      firstName: new FormControl(''),
      lastName: new FormControl(''),
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required]),
      confirm: new FormControl(''),
    });
    this.registerForm
      .get('confirm')
      .setValidators([
        Validators.required,
        this.passConfValidator.validateConfirmPassword(
          this.registerForm.get('password')
        ),
      ]);
  }

  public validateControl = (controlName: string) => {
    return (
      this.registerForm.get(controlName).invalid &&
      this.registerForm.get(controlName).touched
    );
  };
  public hasError = (controlName: string, errorName: string) => {
    return this.registerForm.get(controlName).hasError(errorName);
  };
  public registerUser = (registerFormValue) => {
    this.showError = false;
    const formValues = { ...registerFormValue };
    const user: UserForRegistrationDto = {
      firstName: formValues.firstName,
      lastName: formValues.lastName,
      email: formValues.email,
      password: formValues.password,
      confirmPassword: formValues.confirm,
    };
    this.authService.registerUser('auth/register', user).subscribe({
      next: (_) => this.router.navigate(['/authentication/login']),
      error: (err: HttpErrorResponse) => {
        this.errorMessage = err.message;
        this.showError = true;
      },
    });
  };
}
