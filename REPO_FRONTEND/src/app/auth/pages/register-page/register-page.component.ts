import { Component } from '@angular/core';
import { RegistroComponent } from "../../components/registro/registro.component";

@Component({
  selector: 'app-register-page',
  standalone: true,
  imports: [RegistroComponent],
  templateUrl: './register-page.component.html',
  styleUrl: './register-page.component.scss'
})
export class RegisterPageComponent {

}
