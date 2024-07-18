import { MaterialModule } from '../../../material/material.module';
import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'auth-registro',
  standalone: true,
  imports: [MaterialModule],
  templateUrl: './registro.component.html',
  styleUrl: './registro.component.scss',
})
export class RegistroComponent {
  userName = new FormControl('');
}
