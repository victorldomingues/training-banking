import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AboutPageComponent } from './pages/about-page/about-page.component';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { CarrersPageComponent } from './pages/carrers-page/carrers-page.component';
import { ComercialBankingPageComponent } from './pages/comercial-banking-page/comercial-banking-page.component';
import { CreditCardsPageComponent } from './pages/credit-cards-page/credit-cards-page.component';
import { DevelopersPageComponent } from './pages/developers-page/developers-page.component';
import { FinancingPageComponent } from './pages/financing-page/financing-page.component';
import { InsurancesPageComponent } from './pages/insurances-page/insurances-page.component';
import { InvestmentsPageComponent } from './pages/investments-page/investments-page.component';
import { PlansPageComponent } from './pages/plans-page/plans-page.component';
import { ServicesPageComponent } from './pages/services-page/services-page.component';
import { SignupPageComponent } from './pages/signup-page/signup-page.component';
import { GuardService } from './data/services/guard.service';
import { ServicesModule } from './data/services/services.module';
import { SignupSuccessPageComponent } from './pages/signup-success-page/signup-success.component';
import { AccessDeniedPageComponent } from './pages/access-denied-page/access-denied-page.component';


const routes: Routes = [
  { component: HomePageComponent, path: '', canActivate: [GuardService] },
  { component: AboutPageComponent, path: 'about' },
  { component: CarrersPageComponent, path: 'carrers' },
  { component: ComercialBankingPageComponent, path: 'comercial-banking' },
  { component: CreditCardsPageComponent, path: 'credit-cards' },
  { component: DevelopersPageComponent, path: 'developers' },
  { component: FinancingPageComponent, path: 'financing' },
  { component: InsurancesPageComponent, path: 'insurances' },
  { component: InvestmentsPageComponent, path: 'investments' },
  { component: PlansPageComponent, path: 'plans' },
  { component: ServicesPageComponent, path: 'services' },
  { component: SignupPageComponent, path: 'signup' },
  { component: AccessDeniedPageComponent, path: 'access-denied' },
  { component: SignupSuccessPageComponent, path: 'signup-success', canActivate: [GuardService] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes), ServicesModule],
  exports: [RouterModule]
})
export class AppRoutingModule { }
