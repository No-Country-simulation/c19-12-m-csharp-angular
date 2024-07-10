import { Component } from '@angular/core';
import { MaterialModule } from '../../../material/material.module';
import { NavigationEnd, Router, RouterModule } from '@angular/router';

@Component({
  selector: 'shared-header',
  standalone: true,
  imports: [MaterialModule, RouterModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss',
})
export class HeaderComponent {
  public isAuthRoute: boolean = false;

  constructor(private router : Router){
    this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {
        this.isAuthRoute = event.urlAfterRedirects.includes('auth');
      }
    });
  }
  
  navigateTo(route : string){
    this.router.navigate([route]);
  }
}
