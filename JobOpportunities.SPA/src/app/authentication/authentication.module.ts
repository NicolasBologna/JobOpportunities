import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegisterUserComponent } from './register-user/register-user.component';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { LoginComponent } from './login/login.component';
import { MaterialModule } from '../material.module';

@NgModule({
  declarations: [RegisterUserComponent, LoginComponent],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: 'register', component: RegisterUserComponent },
    ]),
    RouterModule.forChild([{ path: 'login', component: LoginComponent }]),
    ReactiveFormsModule,
    MaterialModule,
  ],
})
export class AuthenticationModule {}
