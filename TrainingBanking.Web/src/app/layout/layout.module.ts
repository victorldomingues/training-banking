import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { NgbPaginationModule, NgbAlertModule, NgbNavModule, NgbModalModule } from '@ng-bootstrap/ng-bootstrap';
import { SigninComponent } from './signin/signin.component';
import { FooterMenuGroupComponent } from './footer-menu-group/footer-menu-group.component';
import { RouterModule } from '@angular/router';
import { NgxMaskModule } from 'ngx-mask';
import { ReactiveFormsModule } from '@angular/forms';
const COMPONENTS = [
  HeaderComponent,
  FooterComponent,
  SigninComponent,
  FooterMenuGroupComponent
];

@NgModule({
  declarations: [...COMPONENTS],
  imports: [
    CommonModule,
    NgbPaginationModule,
    NgbNavModule,
    NgbAlertModule,
    NgbModalModule,
    RouterModule,
    NgxMaskModule.forRoot(),
    ReactiveFormsModule

  ],
  exports: [...COMPONENTS]
})
export class LayoutModule { }
