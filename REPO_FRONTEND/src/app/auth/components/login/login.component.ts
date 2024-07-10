import { Component } from '@angular/core';
import { MaterialModule } from '../../../material/material.module';

@Component({
  selector: 'auth-login',
  standalone: true,
  imports: [
    MaterialModule
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {

}
