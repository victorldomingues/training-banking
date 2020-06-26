import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SignupPageComponent } from './signup-page/signup-page.component';
import { InvestmentsPageComponent } from './investments-page/investments-page.component';
import { AboutPageComponent } from './about-page/about-page.component';
import { PlansPageComponent } from './plans-page/plans-page.component';
import { ServicesPageComponent } from './services-page/services-page.component';
import { DevelopersPageComponent } from './developers-page/developers-page.component';
import { CarrersPageComponent } from './carrers-page/carrers-page.component';
import { CreditCardsPageComponent } from './credit-cards-page/credit-cards-page.component';
import { FinancingPageComponent } from './financing-page/financing-page.component';
import { ComercialBankingPageComponent } from './comercial-banking-page/comercial-banking-page.component';
import { InsurancesPageComponent } from './insurances-page/insurances-page.component';
import { HomePageComponent } from './home-page/home-page.component';
import { ComponentsModule } from '../components/components.module';
import { ReactiveFormsModule } from '@angular/forms';
import { ServicesModule } from '../data/services/services.module';
import { AccessDeniedPageComponent } from './access-denied-page/access-denied-page.component';
import { SignupSuccessPageComponent } from './signup-success-page/signup-success.component';
import { NgbModalModule } from '@ng-bootstrap/ng-bootstrap';

const PAGES = [
  SignupPageComponent,
  InvestmentsPageComponent,
  AboutPageComponent,
  PlansPageComponent,
  ServicesPageComponent,
  DevelopersPageComponent,
  CarrersPageComponent,
  CreditCardsPageComponent,
  FinancingPageComponent,
  ComercialBankingPageComponent,
  InsurancesPageComponent,
  HomePageComponent,
  AccessDeniedPageComponent,
  SignupSuccessPageComponent
];

@NgModule({
  declarations: [...PAGES],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    ComponentsModule,
    NgbModalModule,
    ServicesModule
  ],
  exports: [...PAGES]
})
export class PagesModule { }
