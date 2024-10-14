import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from './core/auth/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {
  constructor(private http: HttpClient, private router: Router, private authService: AuthService) {}
  isLoggedIn: boolean = false;
  ngOnInit() {
    this.isLoggedIn = this.authService.isLoggedIn();
    this.login();
  }

  login(): void {
    this.router.navigate(['../login']);
  }

  logout(): void {
    this.authService.logout();
    this.router.navigate(['../logout']);
  }

  booklist(): void {
    this.router.navigate(['../booklist']);
  }

  title = 'library.client';
}
