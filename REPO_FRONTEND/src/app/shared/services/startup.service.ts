import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StartupService {
  private url = 'http://www.mercado-chamba.somee.com';

  constructor(private http: HttpClient) { }

  callStartupEndpoint(): Observable<any> {
    return this.http.get(this.url);
  }
}
