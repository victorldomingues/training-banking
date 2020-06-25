import { Component, OnInit, Input } from '@angular/core';
import { MenuItem } from 'src/app/models/layout/menu-item.model';

@Component({
  selector: 'app-footer-menu-group',
  templateUrl: './footer-menu-group.component.html',
  styleUrls: ['./footer-menu-group.component.less']
})
export class FooterMenuGroupComponent implements OnInit {
  @Input() title: string;
  @Input() items: MenuItem[];
  constructor() { }

  ngOnInit(): void {
  }

}
