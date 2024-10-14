// login.component.ts
import { HttpClient } from '@angular/common/http';
import { Component, ViewChild, ElementRef } from '@angular/core';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';

interface LoginModel {
  UserName: string;
  Password: string;
}
interface LoginResult {
  token: string;
  role: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './login.component.html',
})

export class LoginComponent {
  constructor(private http: HttpClient, private authService: AuthService, private router: Router) { }
  loginModel: LoginModel = {UserName: "", Password: ""};
  login(): void {
    this.http.post<LoginResult>('/auth/login', this.loginModel).subscribe(
      (result) => {
        const token = result.token;
        const role = result.role;
        this.authService.login(token, role);
        console.log("success login")
        this.router.navigate(['../booklist']);
      },
      (error) => {
        console.error(error);
      }
    );
  }

  register(): void {
    this.router.navigate(['../register']);  }
}
