import { computed, inject, Injectable, signal } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {
  BehaviorSubject,
  catchError,
  map,
  Observable,
  of,
  throwError,
} from 'rxjs';
import { AuthStatus } from '../models/auth-status.enum';
import { LoginResponse } from '../models/login-response.interface';
import { BaseResponse, Status } from '../../shared/models/response.interface';
import { CheckStatusResponse } from '../models/check-status-response.interface';
import { User } from '../models/user.interface';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private readonly API_URL: string = environment.API_URL;
  private http = inject(HttpClient);
  private _currentUser = signal<User | null>(null);
  private _authStatus = signal<AuthStatus>(AuthStatus.checking);

  constructor() {
    
  }

  currentUser = computed(() => this._currentUser());
  authStatus = computed(() => this._authStatus());

  login(userName: string, password: string): Observable<BaseResponse> {
    const url = `${this.API_URL}/api/Login`;
    const body = { userName, password };
    return this.http.post<LoginResponse>(url, body).pipe(
      map(({ message, data, status, isSuccess }) => {
        if (isSuccess) {
          this._authStatus.set(AuthStatus.authenticated);
          localStorage.setItem('token', message);
        }
        return { message, data, status, isSuccess };
      }),
      catchError((error) => throwError(() => error.error.message))
    );
  }

  checkAuthStatus(): Observable<boolean> {
    const url = `${this.API_URL}/api/Login/validate-token`;
    const token = localStorage.getItem('token');
    if (!token) {
      this.logout();
      return of(false);
    }
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    return this.http.get<CheckStatusResponse>(url, { headers }).pipe(
      map(({ data, isSuccess }) => {
        if (!isSuccess) return false
          console.log('Token válido');
          this._currentUser.set(data);
          this._authStatus.set(AuthStatus.authenticated);
          localStorage.setItem('token', token);
          return true;
      }),

      catchError(() => {
        console.log('Error al validar el token');
        this._authStatus.set(AuthStatus.notAuthenticated);
        return of(false);
      })
    );
  }

  logout(): void {
    localStorage.removeItem('token');
    this._currentUser.set(null);
    this._authStatus.set(AuthStatus.notAuthenticated);
  }
}
