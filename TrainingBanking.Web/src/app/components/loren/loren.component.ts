import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-loren',
  templateUrl: './loren.component.html',
  styleUrls: ['./loren.component.less']
})
export class LorenComponent implements OnInit {
  @Input() title: string;

  constructor() { }

  ngOnInit(): void {
  }

}
