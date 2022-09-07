import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MaterialModule } from './material.module';
import { HomeComponent } from './home/home.component';
import { JobOffersComponent } from './jobOffers/jobOffers.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { JobOffersListComponent } from './jobOffers/jobOffers-list/jobOffers-list.component';
import { JobOfferDetailsComponent } from './jobOffers/jobOffer-details/jobOffer-details.component';
import { KnowledgeComponent } from './knowledge/knowledge.component';
import { NotFoundComponent } from './error-pages/not-found/not-found.component';

@NgModule({
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  declarations: [
    AppComponent,
    HomeComponent,
    JobOffersComponent,
    JobOffersListComponent,
    JobOfferDetailsComponent,
    KnowledgeComponent,
    NotFoundComponent,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
