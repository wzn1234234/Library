// login.component.ts
import { HttpClient } from '@angular/common/http';
import { Component, ViewChild, ElementRef } from '@angular/core';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';

interface RegisterModel {
  UserName: string;
  Password: string;
  FirstName: string;
  LastName: string;
  RoleId: number;
}

interface RegisterResult {
  Token: string;
  Role: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './register.component.html',
})

export class RegisterComponent {
  constructor(private http: HttpClient, private authService: AuthService, private router: Router) { }
  registerModel: RegisterModel = { UserName: "", Password: "", FirstName: "", LastName: "", RoleId: 2 };

  register(): void {
    this.http.post<RegisterResult>('/auth/register', this.registerModel).subscribe(
      (result) => {
        const token = result.Token;
        const role = result.Role;
        this.authService.login(token, role);
        console.log("success registered")
      },
      (error) => {
        console.error(error);
      }
    );
  }
  login(): void {
    this.router.navigate(['../login']);
  }
}
