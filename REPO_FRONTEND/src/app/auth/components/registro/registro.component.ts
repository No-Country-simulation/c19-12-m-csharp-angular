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
    firstName: [''],
    lastName: [''],
    email: [''],
    dni: [''],
    phoneNumber: [''],
    password: [''],
    address: [''],
    // countryId : [''],
    // provinceId: [''],
    // neighborhoodId : [''],
  });

  submit() {
    console.log(this.formRegister.value);
  }
}
