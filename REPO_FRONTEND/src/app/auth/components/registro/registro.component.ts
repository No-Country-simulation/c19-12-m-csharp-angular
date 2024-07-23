import { CommonModule } from '@angular/common';
import { MaterialModule } from '../../../material/material.module';
import { Component, inject } from '@angular/core';
import { FormControl } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { UserRegister } from '../../models/user.interface';
import { SnackbarService } from '../../../shared/services/snackbar.service';

@Component({
  selector: 'auth-registro',
  standalone: true,
  imports: [MaterialModule, ReactiveFormsModule, CommonModule, RouterModule],
  templateUrl: './registro.component.html',
  styleUrl: './registro.component.scss',
})
export class RegistroComponent {
  private fb = inject(FormBuilder);
  private authService = inject(AuthService);
  private router = inject(Router);
  private snackbarService = inject(SnackbarService);
  public errors = [];

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
    const userRegister: UserRegister = this.formRegister.value;
    this.authService.register(userRegister)
    .subscribe({
      next: (response) => {
        if (response.isSuccess) {
          this.snackbarService.openSuccessSnackBar('Usuario registrado correctamente');
          this.router.navigateByUrl('/auth/login');
        } 
      },
      error: (error) => {
        this.snackbarService.openErrorSnackBar('Usuario no registrado');
        this.errors = error;
      },
    });
  }
}
