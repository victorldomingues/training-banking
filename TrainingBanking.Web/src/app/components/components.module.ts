import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LorenComponent } from './loren/loren.component';
import { InputComponent } from './input/input.component';
import { ReactiveFormsModule } from '@angular/forms';
import { NgxMaskModule } from 'ngx-mask';
import { AlertModalComponent } from './alert-modal/alert-modal.component';
import { NgbModalModule } from '@ng-bootstrap/ng-bootstrap';
const COMPONENTS = [
  LorenComponent,
  InputComponent
];

@NgModule({
  declarations: [...COMPONENTS, AlertModalComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    NgbModalModule,
    NgxMaskModule.forRoot()

  ],
  exports: [...COMPONENTS]
})
export class ComponentsModule { }
