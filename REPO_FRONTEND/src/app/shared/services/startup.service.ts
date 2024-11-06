import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StartupService {
  private url = 'https://www.mercado-chamba.somee.com/swagger/index.html';

  constructor(private http: HttpClient) { }

  callStartupEndpoint(): Observable<any> {
    return this.http.get(this.url);
  }
}
