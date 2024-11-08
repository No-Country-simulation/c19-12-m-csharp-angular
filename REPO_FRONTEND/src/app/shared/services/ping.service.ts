// ping.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PingService {
  constructor(private http: HttpClient) {}

  sendPing() {
    this.http.get('https://mercado-chamba.somee.com/ping').subscribe({
      next: () => console.log('Backend activado'),
      error: (err) => console.error('Error en el ping:', err)
    });
  }
}
