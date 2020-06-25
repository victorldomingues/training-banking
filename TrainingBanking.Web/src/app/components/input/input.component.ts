import { Component, OnInit, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-input',
  templateUrl: './input.component.html',
  styleUrls: ['./input.component.less']
})
export class InputComponent implements OnInit {
  @Input() form: FormGroup;
  @Input() name: string;
  @Input() placeholder: string;
  @Input() error: string;
  @Input() type: string;
  @Input() mask: string;
  constructor() { }

  ngOnInit(): void {
  }

}
