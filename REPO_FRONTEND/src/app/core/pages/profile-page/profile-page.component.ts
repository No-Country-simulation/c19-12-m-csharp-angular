import { Component } from '@angular/core';
import { HeaderComponent } from '../../../shared/components/header/header.component';
import { MaterialModule } from '../../../material/material.module';
import { CommonModule } from '@angular/common';
import { CardService } from '../../services/card.service';
import { Card, IdCard } from '../../models/card.interface';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-profile-page',
  standalone: true,
  imports: [CommonModule, MaterialModule, HeaderComponent, RouterModule],
  templateUrl: './profile-page.component.html',
  styleUrl: './profile-page.component.scss',
})
export class ProfilePageComponent {
  public card: Card | null = null;

  constructor(
    private cardService: CardService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe((params) => {
      const id = params.get('id');
      if (id) {
        this.loadCard(Number(id));
      } else {
        this.router.navigate(['/']);
      }
    });
  }

  private loadCard(id: number): void {
    const card = this.cardService.getCardById(id);
    if (card) {
      this.card = card;
    } else {
      console.error(`Card with id ${id} not found`);
      this.router.navigate(['/']);
    }
  }
}
