import { Component, OnInit } from '@angular/core';
import { GuardService } from 'src/app/data/services/guard.service';
import { User } from 'src/app/models/user.model';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.less']
})
export class HomePageComponent implements OnInit {

  user: User;
  constructor(private guardService: GuardService) { }

  ngOnInit(): void {
    const { email, unique_name } = this.guardService.getUser();
    this.user = { email, name: unique_name } as User;
  }

}
