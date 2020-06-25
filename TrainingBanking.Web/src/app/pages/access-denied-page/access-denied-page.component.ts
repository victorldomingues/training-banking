import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-access-denied-page',
  templateUrl: './access-denied-page.component.html',
  styleUrls: ['./access-denied-page.component.less']
})
export class AccessDeniedPageComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {
  }
  goSignup() {
    this.router.navigate(['signup']);
  }
}
