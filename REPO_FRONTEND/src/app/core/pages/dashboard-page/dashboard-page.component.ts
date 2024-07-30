import { Component } from '@angular/core';
import { UpdateProfileComponent } from '../../components/update-profile/update-profile.component';
import { AuthService } from '../../../auth/services/auth.service';
import { User } from '../../../auth/models/user.interface';

@Component({
  selector: 'core-dashboard-page',
  standalone: true,
  imports: [UpdateProfileComponent],
  templateUrl: './dashboard-page.component.html',
  styleUrl: './dashboard-page.component.scss',
})
export class DashboardPageComponent {
  public user: User | null = null;
  constructor(private authService: AuthService) {
    console.log(this.authService.currentUser());
    this.user = this.authService.currentUser();
  }
}
