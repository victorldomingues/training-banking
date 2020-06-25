import { Component, OnInit } from '@angular/core';
import { GuardService } from 'src/app/data/services/guard.service';
import { User } from 'src/app/models/user.model';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.less']
})
export class SigninComponent implements OnInit {
  user: User;
  isAuthenticated: boolean;
  form: FormGroup;
  constructor(private guardService: GuardService, private router: Router, private fb: FormBuilder) {
    this.form = this.fb.group({
      cpf: [null, Validators.required]
    });
  }

  ngOnInit(): void {
    this.guardService.tokenChange.subscribe((data) => {
      if (data != null) {
        const { email, unique_name } = data;
        this.user = { email, name: unique_name } as User;
        this.isAuthenticated = this.guardService.isAuthenticated();
        return;
      }
      this.isAuthenticated = false;
    });
    this.guardService.load();


  }
  signin() {
    const { cpf } = this.form.value;
    this.guardService.signin$(cpf).subscribe(result => {
      const user = this.guardService.getUser();
      this.guardService.tokenChangeObserver.next(user);
      this.router.navigate(['']);
    }, error => {

    });
  }
  signout() {
    this.guardService.clear();
    this.router.navigate(['access-denied']);
  }

}
