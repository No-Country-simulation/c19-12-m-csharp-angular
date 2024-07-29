import { inject, Injectable } from '@angular/core';
import { Card } from '../models/card.interface';
import { Observable, of } from 'rxjs';
import { CategoryService } from './category.service';

@Injectable({
  providedIn: 'root',
})
export class ListCardsService {
  listCards: Card[] = [
    {
      id_user: 1,
      fullName: 'Marvin Black',
      category: 'Carpintería',
      cantReviews: 23,
      ranking: 3,
      picUrl: 'https://randomuser.me/api/portraits/men/0.jpg',
    },
    {
      id_user: 2,
      fullName: 'Shane Nguyen',
      category: 'Pintura',
      cantReviews: 23,
      ranking: 3,
      picUrl: 'https://randomuser.me/api/portraits/men/1.jpg',
    },
    {
      id_user: 3,
      fullName: 'Shane Nguyen',
      category: 'Plomería',
      cantReviews: 23,
      ranking: 3,
      picUrl: 'https://randomuser.me/api/portraits/men/2.jpg',
    },
    {
      id_user: 4,
      fullName: 'Esther Miles',
      category: 'Cocina',
      cantReviews: 23,
      ranking: 3,
      picUrl: 'https://randomuser.me/api/portraits/women/1.jpg',
    },
    {
      id_user: 5,
      fullName: 'Marvin Black',
      category: 'Electricidad',
      cantReviews: 23,
      ranking: 3,
      picUrl: 'https://randomuser.me/api/portraits/men/3.jpg',
    },
    {
      id_user: 6,
      fullName: 'Alice Johnson',
      category: 'Plomería',
      cantReviews: 15,
      ranking: 4,
      picUrl: 'https://randomuser.me/api/portraits/women/2.jpg',
    },
    {
      id_user: 7,
      fullName: 'Bob Smith',
      category: 'Carpintería',
      cantReviews: 10,
      ranking: 4.5,
      picUrl: 'https://randomuser.me/api/portraits/men/4.jpg',
    },
    {
      id_user: 8,
      fullName: 'Charlie Brown',
      category: 'Pintura',
      cantReviews: 20,
      ranking: 3.8,
      picUrl: 'https://randomuser.me/api/portraits/men/6.jpg',
    },
    {
      id_user: 9,
      fullName: 'Diana Green',
      category: 'Electricidad',
      cantReviews: 18,
      ranking: 4.2,
      picUrl: 'https://randomuser.me/api/portraits/women/3.jpg',
    },
    {
      id_user: 10,
      fullName: 'Eva White',
      category: 'Jardinería',
      cantReviews: 12,
      ranking: 3.5,
      picUrl: 'https://randomuser.me/api/portraits/women/6.jpg',
    },
  ];

  private _text: string = '';

  constructor(private categoryService: CategoryService) {}

  public get text(): string {
    return this._text;
  }

  public searchText(text: string): void {
    this._text = text;
  }

  public filteredCards(): Observable<Card[]> {
    const category = this.categoryService.selectedCategory().name;
    const text = this._text;

    if (text === '') {
      return of(
        this.listCards.filter(
          (card) => category === 'Todos' || card.category === category
        )
      );
    }

    const cards = this.listCards.filter((card) => {
      const matchesText =
       this.normalizeText(card.fullName).includes(this.normalizeText(text)) ||
       this.normalizeText(card.category).includes(this.normalizeText(text));
      const matchesCategory =
        category === 'Todos' || card.category === category;
      return matchesText && matchesCategory;
    });

    return of(cards);
  }

  private normalizeText(text: string): string {
    return text.normalize('NFD').replace(/[\u0300-\u036f]/g, '').toLowerCase();
  }
}
