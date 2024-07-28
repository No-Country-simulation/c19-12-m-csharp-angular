import { Injectable } from '@angular/core';
import { ListCardsService } from './list-cards.service';
import { Card, IdCard } from '../models/card.interface';

@Injectable({
  providedIn: 'root',
})
export class CardService {
  private cards: Card[] = [];

  constructor(private listCardsService: ListCardsService) {
    this.cards = this.listCardsService.listCards;
  }

  getCardById(id: IdCard) {
    return this.cards.find((card) => card.id_user === id);
  }
}
