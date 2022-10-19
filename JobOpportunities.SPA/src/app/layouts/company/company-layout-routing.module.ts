import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminGuard } from 'src/app/common/guards/admin.guard';
import { AuthGuard } from 'src/app/common/guards/auth.guard';
import { PrivacyComponent } from 'src/app/privacy/privacy.component';
import { CompanyLayoutComponent } from './company-layout.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  {
    path: 'home',
    component: CompanyLayoutComponent,
    children: [
      {
        path: '',
        component: HomeComponent,
      },
    ],
  },
  {
    path: 'job-offers',
    loadChildren: () =>
      import('./../../job-offers/job-offers.module').then(
        (m) => m.JobOffersModule
      ),
  },
  {
    path: 'skill-levels',
    loadChildren: () =>
      import('./../../skill-levels/skill-levels.module').then(
        (m) => m.SkillLevelsModule
      ),
  },
  {
    path: 'skills',
    loadChildren: () =>
      import('./../../skills/skills.module').then((m) => m.SkillsModule),
  },
  {
    path: 'company-agents',
    loadChildren: () =>
      import('./../../company-agents/company-agents.module').then(
        (m) => m.CompanyAgentsModule
      ),
  },
  {
    path: 'privacy',
    component: PrivacyComponent,
    canActivate: [AuthGuard, AdminGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CompanyLayoutRoutingModule {}
