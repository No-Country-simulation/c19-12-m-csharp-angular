import { Component, OnInit } from '@angular/core';
import { MaterialModule } from '../../../material/material.module';
import { NgFor } from '@angular/common';

interface categoriesInterface {
  id: string;
  name: string;
}

const categories: categoriesInterface[] = [
  { id: '0', name: 'Todos' },
  { id: '1', name: 'refrigeracion' },
  { id: '2', name: 'electricidad' },
  { id: '3', name: 'vidrios' },
  { id: '4', name: 'electricidad' },
  { id: '5', name: 'carpintero' },
  { id: '6', name: 'pintor' },
  { id: '7', name: 'mecanica' },
];

@Component({
  selector: 'app-filters',
  standalone: true,
  imports: [MaterialModule, NgFor],
  templateUrl: './filters.component.html',
  styleUrl: './filters.component.scss',
})
export class FiltersComponent implements OnInit {
  constructor() {}
  ngOnInit(): void {}
  containtCategories = categories;
}
