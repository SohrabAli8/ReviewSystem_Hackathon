import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';
import { environment } from '../../environments/environment';
import { LoginRequest, RegisterRequest, AuthResponse } from '../models/auth';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private apiUrl = `${environment.apiUrl}/auth`;

  constructor(private http: HttpClient) { }

  login(dto: LoginRequest): Observable<AuthResponse> {
    return this.http.post<AuthResponse>(`${this.apiUrl}/login`, dto).pipe(
      tap(res => {
        if (res && res.token) {
          localStorage.setItem('token', res.token);
        }
      })
    );
  }

  register(dto: RegisterRequest): Observable<any> {
    return this.http.post(`${this.apiUrl}/register`, dto, { responseType: 'text' });
  }

  logout(): void {
    localStorage.removeItem('token');
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }

  isLoggedIn(): boolean {
    return !!this.getToken();
  }

  getUserRole(): string | null {
    const token = this.getToken();
    if (!token) return null;

    try {
      const payload = JSON.parse(atob(token.split('.')[1]));
      // The claim matching the role enum logic in .NET identity is often specific URL format or simple 'role'
      return payload['role'] || payload['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] || null;
    } catch {
      return null;
    }
  }
}
