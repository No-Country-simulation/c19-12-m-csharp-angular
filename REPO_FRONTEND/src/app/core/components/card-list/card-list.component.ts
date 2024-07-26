import { Component, inject, Input } from '@angular/core';
import { Card } from '../../models/card.interface';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../../../material/material.module';

@Component({
  selector: 'app-card-list',
  standalone: true,
  imports: [CommonModule, MaterialModule],
  templateUrl: './card-list.component.html',
  styleUrl: './card-list.component.scss',
})
export class CardListComponent {
  
  @Input()
  professionals: Card[] = [];
}
