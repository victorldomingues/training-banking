// tslint:disable
import { Injectable } from '@angular/core';
import { User } from 'src/app/models/user.model';
import jwtDecode from 'jwt-decode';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { tap } from 'rxjs/operators';
import { Observable, Observer } from 'rxjs';
import { Router } from '@angular/router';
@Injectable({
  providedIn: 'root'
})
export class GuardService {

  private token: string;
  private user: any;

  tokenChange: Observable<any>;
  tokenChangeObserver: Observer<any>;

  constructor(
    private http: HttpClient,
    private router: Router
  ) {
    this.tokenChange = new Observable((observer: Observer<any>) => {
      this.tokenChangeObserver = observer;
    });
  }

  create$(user: User): Observable<{ token: string, user: User }> {
    return this.http
      .post<{ token: string, user: User }>(`${environment.api.host}account/signup`, user)
      .pipe(tap(this.saveToken.bind(this)));
  }
  signin$(cpf: string) {
    return this.http
      .post<{ token: string }>(`${environment.api.host}account/signin`, { cpf })
      .pipe(tap(this.saveToken.bind(this)));
  }
  getToken() {

    if (this.token == null)
      this.token = localStorage.getItem('token');

    if (this.token == null)
      return this.token;

    const payload = jwtDecode(this.token);
    this.user = payload;
    return this.token;

  }
  getUser() {
    if (this.user == null)
      this.getToken();
    return this.user;
  }

  isAuthenticated(): boolean {
    const token = this.getToken();
    if (token == null) return false;
    const now = new Date()
    const expires = new Date(this.user.exp * 1000);
    return token != null && expires > now;
  }

  canActivate(): boolean {
    if (!this.isAuthenticated()) {
      this.router.navigate(['access-denied']);
      return false;
    }
    return true;
  }

  saveToken({ token }: { token: string }) {
    if (token == null) return;
    this.token = token;
    const payload = jwtDecode(token);
    this.user = payload;
    localStorage.setItem('token', token);
    this.tokenChangeObserver.next(this.user);
  }
  clear() {
    this.token = null;
    this.user = null;
    localStorage.clear();
    this.tokenChangeObserver.next(null);
  }

  load() {
    const user = this.getUser();
    this.tokenChangeObserver.next(user);
  }
}
