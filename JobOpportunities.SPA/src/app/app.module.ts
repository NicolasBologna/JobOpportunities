import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MaterialModule } from './material.module';
import { HomeComponent } from './home/home.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { KnowledgeComponent } from './knowledge/knowledge.component';
import { NotFoundComponent } from './error-pages/not-found/not-found.component';
import { JobOffersModule } from './job-offers/job-offers.module';
import { SkillLevelsModule } from './skill-levels/skill-levels.module';
import { InternalServerComponent } from './error-pages/internal-server/internal-server.component';
import { SkillsModule } from './skills/skills.module';
import { BootstrapModule } from './bootstrap.module';
import { ErrorHandlerService } from './common/services/error-handler.service';
import { JwtModule } from '@auth0/angular-jwt';
import { PrivacyComponent } from './privacy/privacy.component';
import { ForbiddenComponent } from './error-pages/forbidden/forbidden.component';
import { FlexLayoutModule } from '@angular/flex-layout';
import { AuthModule } from './layouts/auth/auth.module';

export function tokenGetter() {
  return localStorage.getItem('token');
}

@NgModule({
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    JobOffersModule,
    SkillLevelsModule,
    SkillsModule,
    BootstrapModule,
    FlexLayoutModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ['localhost:7278'], //Esto le dice que a todo lo que tenga este dominio le meta el JWT
        disallowedRoutes: [],
      },
    }),
    AuthModule,
  ],
  declarations: [
    AppComponent,
    HomeComponent,
    KnowledgeComponent,
    NotFoundComponent,
    InternalServerComponent,
    PrivacyComponent,
    ForbiddenComponent,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorHandlerService,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
