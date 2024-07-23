import { Component, inject, OnInit } from '@angular/core';
import { MaterialModule } from '../../../material/material.module';
import { Router, RouterModule } from '@angular/router';
import { AuthService } from '../../../auth/services/auth.service';
import { User } from '../../../auth/models/user.interface';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'core-dashboard-layout',
  standalone: true,
  imports: [MaterialModule, RouterModule, CommonModule],
  templateUrl: './dashboard-layout.component.html',
  styleUrl: './dashboard-layout.component.scss',
})
export class DashboardLayoutComponent implements OnInit{
  showFiller = false;

  private authService = inject(AuthService);
  private router = inject(Router);
  public user: User | null = null;

  constructor() {
    
  }

  ngOnInit(): void {
    this.user = this.authService.currentUser();
  }

  

  handleLogout(): void {
    this.authService.logout();
    this.router.navigateByUrl('/auth/login');
  }
}
