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
  { path: '404', component: NotFoundComponent },
  { path: '403', component: ForbiddenComponent },
  { path: '500', component: InternalServerComponent },
  {
    path: 'auth',
    loadChildren: () =>
      import('./layouts/auth/auth.module').then((m) => m.AuthModule),
  },
  {
    matcher: (url) => {
      const user_type = localStorage.getItem('user_type');
      if (user_type === 'CompanyAgent') {
        console.log('entre');

        return url.length ? { consumed: [] } : { consumed: url };
      }
      return null;
    },
    loadChildren: () =>
      import('./layouts/company/company-layout.module').then(
        (m) => m.CompanyLayoutModule
      ),
    canActivate: [AuthGuard],
  },
  { path: '', redirectTo: '/auth', pathMatch: 'full' },
  { path: '**', redirectTo: '/404', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
