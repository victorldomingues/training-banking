import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'src/app/models/layout/menu-item.model';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.less']
})
export class HeaderComponent implements OnInit {


  items: MenuItem[] = [
    { title: 'Abra sua conta', route: '/signup' },
    { title: 'Investimentos', route: '/investments' },
    { title: 'Planos', route: '/plans' },
  ];

  constructor() {
  }

  ngOnInit(): void {
  }

}
