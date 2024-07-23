import { Component, OnInit } from '@angular/core';
import { MaterialModule } from '../../../material/material.module';
import { NgFor } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms';

interface categoriesInterface {
  id: string;
  name: string;
  icon: string;
}

const categories: categoriesInterface[] = [
  { id: '0', name: 'Todos', icon: 'public' },
  { id: '1', name: 'Refrigeracion', icon: 'ac_unit' },
  { id: '2', name: 'Electricidad', icon: 'electric_bolt' },
  { id: '3', name: 'Vidrios', icon: 'window' },
  { id: '4', name: 'Electricidad', icon: 'electric_bolt' },
  { id: '5', name: 'Carpintero', icon: 'carpenter' },
  { id: '6', name: 'Pintor', icon: 'format_paint' },
  { id: '7', name: 'Mecanica', icon: 'car_crash' },
];

@Component({
  selector: 'app-filters',
  standalone: true,
  imports: [
    MaterialModule,
    NgFor,
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    FormsModule,
  ],
  templateUrl: './filters.component.html',
  styleUrl: './filters.component.scss',
})
export class FiltersComponent implements OnInit {
  constructor() {}
  ngOnInit(): void {}
  containtCategories = categories;
  search: String = '';
}
