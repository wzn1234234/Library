// authentication.service.ts
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private jwtHelper = new JwtHelperService();

  login(token: string, role: string): void {
    localStorage.setItem('token', token);
    localStorage.setItem('role', role);
    console.log('token added');
    console.log(localStorage.getItem('token'));
  }

  register(token: string, role: string): void {
    localStorage.setItem('token', token);
    localStorage.setItem('role', role);
  }

  logout(): void {
    console.log('token removed');
    localStorage.removeItem('token');
    localStorage.removeItem('role');
  }

  getToken(): string | null {
    console.log(localStorage.getItem('token'));
    return localStorage.getItem('token');
    
  }

  isLoggedIn(): boolean {
    const token = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token);
  }

  isLibrarian(): boolean {
    const role = localStorage.getItem('role');
    return role == "Librarian";
  }

  isCustomer(): boolean {
    const role = localStorage.getItem('role');
    return role == "Customer";
  }
}
