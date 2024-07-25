import { CommonModule, NgFor } from '@angular/common';
import { Component } from '@angular/core';
import { FooterComponent } from '../../../shared/components/footer/footer.component';
import { HeaderComponent } from '../../../shared/components/header/header.component';
import { MaterialModule } from '../../../material/material.module';
import { FiltersComponent } from '../../../shared/components/filters/filters.component';
// import { StarRatingModule } from 'angular-star-rating';

interface propCards {
  id_user: number;
  fullName: string;
  category: string;
  cantReviews: number;
  ranking: number;
  picUrl: string;
}

const listCards: propCards[] = [
  {
    id_user: 1,
    fullName: 'Marvin Black',
    category: 'Carpinteria',
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
    category: 'Soldador',
    cantReviews: 23,
    ranking: 3,
    picUrl: 'https://randomuser.me/api/portraits/men/2.jpg',
  },
  {
    id_user: 4,
    fullName: 'Esther Miles',
    category: 'Cocinero',
    cantReviews: 23,
    ranking: 3,
    picUrl: 'https://randomuser.me/api/portraits/women/1.jpg',
  },
  {
    id_user: 5,
    fullName: 'Marvin Black',
    category: 'Electricista',
    cantReviews: 23,
    ranking: 3,
    picUrl: 'https://randomuser.me/api/portraits/men/3.jpg',
  },
  {
    id_user: 6,
    fullName: 'Alice Johnson',
    category: 'Fontanero',
    cantReviews: 15,
    ranking: 4,
    picUrl: 'https://randomuser.me/api/portraits/women/2.jpg',
  },
  {
    id_user: 7,
    fullName: 'Bob Smith',
    category: 'Carpintero',
    cantReviews: 10,
    ranking: 4.5,
    picUrl: 'https://randomuser.me/api/portraits/men/4.jpg',
  },
  {
    id_user: 8,
    fullName: 'Charlie Brown',
    category: 'Pintor',
    cantReviews: 20,
    ranking: 3.8,
    picUrl: 'https://randomuser.me/api/portraits/men/6.jpg',
  },
  {
    id_user: 9,
    fullName: 'Diana Green',
    category: 'Electricista',
    cantReviews: 18,
    ranking: 4.2,
    picUrl: 'https://randomuser.me/api/portraits/women/3.jpg',
  },
  {
    id_user: 10,
    fullName: 'Eva White',
    category: 'Jardinero',
    cantReviews: 12,
    ranking: 3.5,
    picUrl: 'https://randomuser.me/api/portraits/women/6.jpg',
  },
];
@Component({
  selector: 'app-index',
  standalone: true,
  imports: [
    CommonModule,
    HeaderComponent,
    FooterComponent,
    MaterialModule,
    FiltersComponent,
    NgFor,
    // StarRatingModule,
  ],
  templateUrl: './index.component.html',
  styleUrl: './index.component.scss',
})
export class IndexComponent {
  profesionales = listCards;
}
