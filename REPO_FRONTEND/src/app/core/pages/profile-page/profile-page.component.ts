import { Component } from '@angular/core';
import { HeaderComponent } from '../../../shared/components/header/header.component';
import { MaterialModule } from '../../../material/material.module';
import { CommonModule } from '@angular/common';
import { CardService } from '../../services/card.service';

import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { Card, IdCard } from '../../models/card.interface';
import { CategoriesToStringPipe } from "../../pipes/categories-to-string.pipe";

@Component({
  selector: 'app-profile-page',
  standalone: true,
  imports: [CommonModule, MaterialModule, HeaderComponent, RouterModule, CategoriesToStringPipe],
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

  private loadCard(id: IdCard): void {
    const card = this.cardService.getCardById(id).subscribe(
      (response) => {
        this.card = response.data;
      },
      (error) => {
        console.error('Error loading card:', error);
        this.router.navigate(['/']);
      }
    );
  }
}
