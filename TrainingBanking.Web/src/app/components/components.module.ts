import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LorenComponent } from './loren/loren.component';
import { InputComponent } from './input/input.component';
import { ReactiveFormsModule } from '@angular/forms';
import { NgxMaskModule } from 'ngx-mask';
const COMPONENTS = [
  LorenComponent,
  InputComponent
];

@NgModule({
  declarations: [...COMPONENTS],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    NgxMaskModule.forRoot()

  ],
  exports: [...COMPONENTS]
})
export class ComponentsModule { }
