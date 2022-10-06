import { HttpClientModule } from '@angular/common/http';
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
  ],
  declarations: [
    AppComponent,
    HomeComponent,
    KnowledgeComponent,
    NotFoundComponent,
    InternalServerComponent,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
