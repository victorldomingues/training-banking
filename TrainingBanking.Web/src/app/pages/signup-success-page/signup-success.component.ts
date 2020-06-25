import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { GuardService } from 'src/app/data/services/guard.service';
import { toJSDate } from '@ng-bootstrap/ng-bootstrap/datepicker/ngb-calendar';

@Component({
  selector: 'app-signup-success',
  templateUrl: './signup-success.component.html',
  styleUrls: ['./signup-success.component.less']
})
export class SignupSuccessPageComponent implements OnInit {

  constructor(private router: Router, private guardService: GuardService) { }

  ngOnInit(): void {
    setTimeout(this.goHome.bind(this), 10000);
  }

  goHome() {
    if (!this.guardService.isAuthenticated()) {
      return;
    }
    const user = this.guardService.getUser();
    this.guardService.tokenChangeObserver.next(user);
    this.router.navigate(['']);
  }

}
