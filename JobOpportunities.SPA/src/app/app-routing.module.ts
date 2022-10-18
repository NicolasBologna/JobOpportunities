import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { JobOffersComponent } from './job-offers/job-offers.component';
import { HomeComponent } from './home/home.component';
import { NotFoundComponent } from './error-pages/not-found/not-found.component';
import { InternalServerComponent } from './error-pages/internal-server/internal-server.component';
import { AuthGuard } from './common/guards/auth.guard';
import { PrivacyComponent } from './privacy/privacy.component';
import { ForbiddenComponent } from './error-pages/forbidden/forbidden.component';
import { AdminGuard } from './common/guards/admin.guard';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  {
    path: 'authentication',
    loadChildren: () =>
      import('./authentication/authentication.module').then(
        (m) => m.AuthenticationModule
      ),
  },
  {
    path: 'job-offers',
    loadChildren: () =>
      import('./job-offers/job-offers.module').then((m) => m.JobOffersModule),
    canActivate: [AuthGuard],
  },
  {
    path: 'skill-levels',
    loadChildren: () =>
      import('./skill-levels/skill-levels.module').then(
        (m) => m.SkillLevelsModule
      ),
  },
  {
    path: 'skills',
    loadChildren: () =>
      import('./skills/skills.module').then((m) => m.SkillsModule),
  },
  {
    path: 'company-agents',
    loadChildren: () =>
      import('./company-agents/company-agents.module').then(
        (m) => m.CompanyAgentsModule
      ),
  },
  {
    path: 'privacy',
    component: PrivacyComponent,
    canActivate: [AuthGuard, AdminGuard],
  },
  { path: '404', component: NotFoundComponent },
  { path: '403', component: ForbiddenComponent },
  { path: '500', component: InternalServerComponent },
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: '**', redirectTo: '/404', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
