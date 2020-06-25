import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'src/app/models/layout/menu-item.model';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.less']
})
export class FooterComponent implements OnInit {

  trainingBankMenu: MenuItem[] = [
    { title: 'Quem somos', route: '/about' },
    { title: 'Nossos serviços', route: '/services' },
    { title: 'Carreiras', route: '/carrers' },
    { title: 'Desenvolvedores', route: '/developers' }
  ];

  forYouMenu: MenuItem[] = [
    { title: 'Abra sua conta', route: '/signup' },
    { title: 'Cartões de crédito', route: '/credit-cards' },
    { title: 'Créditos e financiamento', route: '/financing' },
    { title: 'Investimentos pessoa fisica', route: '/investments' }
  ];

  segmentsMenu: MenuItem[] = [
    { title: 'Comercial Banking', route: '/comercial-banking' },
    { title: 'Seguros', route: '/insurances' },
    { title: 'Tesouro direto', route: '/investments' }
  ];

  constructor() { }

  ngOnInit(): void {
  }




}
