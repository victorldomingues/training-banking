// tslint:disable
import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { GuardService } from 'src/app/data/services/guard.service';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { Router } from '@angular/router';
@Component({
  selector: 'app-signup-page',
  templateUrl: './signup-page.component.html',
  styleUrls: ['./signup-page.component.less']
})
export class SignupPageComponent implements OnInit, OnDestroy {
  sub: Subject<any> = new Subject();
  form: FormGroup;
  busy = false;

  constructor(private fb: FormBuilder, private guardService: GuardService, private router: Router) {
    this.form = this.fb.group({
      name: [null, Validators.required],
      cpf: [null, Validators.required],
      email: [null, [Validators.required, Validators.email]],
      phone: [null, Validators.required],
      address: [null, Validators.required],
    });
  }
  ngOnDestroy(): void {
    this.sub.next();
    this.sub.complete();
  }

  ngOnInit(): void {
    if (this.guardService.isAuthenticated()) {
      this.router.navigate(['']);
    }
  }

  submit() {

    if (this.busy) return;
    if (this.form.invalid) return;
    this.busy = true;
    this.form.disable();
    this.guardService.create$(this.form.value)
      .pipe(takeUntil(this.sub))
      .subscribe(result => {
        this.router.navigate(['signup-success']);
        this.busy = false;
        this.form.enable();
        const user = this.guardService.getUser();
        this.guardService.tokenChangeObserver.next(user);
      }, error => {
        this.busy = false
        this.form.enable;
      });

  }

}
