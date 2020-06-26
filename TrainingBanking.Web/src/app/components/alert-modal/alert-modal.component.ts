import { Component, OnInit, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-alert-modal',
  templateUrl: './alert-modal.component.html',
  styleUrls: ['./alert-modal.component.less']
})
export class AlertModalComponent implements OnInit {

  @Input() content;
  @Input() title;

  constructor(public activeModal: NgbActiveModal) { }

  ngOnInit(): void {
  }

}
