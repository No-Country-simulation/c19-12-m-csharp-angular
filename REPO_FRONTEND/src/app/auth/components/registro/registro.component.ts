import { CommonModule } from '@angular/common';
import { MaterialModule } from '../../../material/material.module';
import { Component, inject } from '@angular/core';
import { FormControl } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'auth-registro',
  standalone: true,
  imports: [MaterialModule, ReactiveFormsModule, CommonModule],
  templateUrl: './registro.component.html',
  styleUrl: './registro.component.scss',
})
export class RegistroComponent {
  private fb = inject(FormBuilder);

  public formRegister = this.fb.group({
    userName: ['', [Validators.required, Validators.minLength(6)]],
    firstName: ['', [Validators.required, Validators.minLength(2)]],
    lastName: ['', [Validators.required, Validators.minLength(2)]],
    email: ['', [Validators.required, Validators.email]],
    dni: ['', [Validators.required, Validators.minLength(8)]],
    phoneNumber: ['', [Validators.required, Validators.minLength(8)]],
    password: ['', [Validators.required, Validators.minLength(2)]],
    address: ['', [Validators.required, Validators.minLength(2)]],
    // countryId : [''],
    // provinceId: [''],
    // neighborhoodId : [''],
  });

  submit() {
    console.log(this.formRegister.value);
  }
}
