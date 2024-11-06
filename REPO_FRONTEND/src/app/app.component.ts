import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { StartupService } from './shared/services/startup.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent implements OnInit {
  title = 'chicos';

  constructor(private startupService: StartupService) {}

  ngOnInit(): void {
    this.startupService.callStartupEndpoint().subscribe(
      (response) => {
        console.log('Conexion habilitada:', response);
      },
      (error) => {
        console.error('Error al habilitar la conexion:', error);
      }
    );
  }
}
