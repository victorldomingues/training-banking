import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GuardService } from './guard.service';

import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [],
  providers: [GuardService],
  imports: [
    CommonModule,
    HttpClientModule
  ]
})
export class ServicesModule { }
