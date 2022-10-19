import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthRoutingModule } from './auth-routing.module';
import { AuthLayoutComponent } from './auth-layout.component';
import { FlexLayoutModule } from '@angular/flex-layout';

@NgModule({
  declarations: [AuthLayoutComponent],
  imports: [CommonModule, AuthRoutingModule, FlexLayoutModule],
})
export class AuthModule {}
