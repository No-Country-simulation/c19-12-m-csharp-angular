import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { PingService } from './shared/services/ping.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent {
  title = 'chicos';

  constructor(private pingService: PingService) {}

  ngOnInit() {
    this.pingService.sendPing();
  }
}
