import { Component, OnInit } from '@angular/core';
import { GuardService } from 'src/app/data/services/guard.service';
import { User } from 'src/app/models/user.model';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/components/alert-modal/alert-modal.component';
@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.less']
})
export class SigninComponent implements OnInit {
  user: User;
  isAuthenticated: boolean;
  form: FormGroup;

  constructor(private guardService: GuardService, private router: Router, private fb: FormBuilder, private modalService: NgbModal) {
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
    this.guardService.signin$(cpf).subscribe(() => {
      const user = this.guardService.getUser();
      this.guardService.tokenChangeObserver.next(user);
      this.router.navigate(['']);
    }, ({ error }) => {
      if (error && error.errors) {
        const errStr = error.errors.map(x => x.message).join(',\n');
        this.open(errStr);
        return;
      }
      this.open('Ocorreu um erro inesperado');
    });
  }
  signout() {
    this.guardService.clear();
    this.router.navigate(['access-denied']);
  }

  open(message: string) {
    const modalRef = this.modalService.open(AlertModalComponent);
    modalRef.componentInstance.content = message;
    modalRef.componentInstance.title = 'Erro';
  }

}
