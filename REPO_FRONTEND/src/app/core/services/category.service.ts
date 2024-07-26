import { computed, Injectable, signal } from '@angular/core';

import { Observable, of } from 'rxjs';
import { Category, IdCategory } from '../models/category.interface';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  
  private _selectedCategory: Category = {
    id: '0',
    name: 'Todos',
    icon: 'public'
  };

  private categories: Category[] = [
    { id: '0', name: 'Todos', icon: 'public' },
    { id: '1', name: 'Refrigeración', icon: 'ac_unit' },
    { id: '2', name: 'Electricidad', icon: 'electric_bolt' },
    { id: '3', name: 'Vidrios', icon: 'window' },
    { id: '4', name: 'Plomearía', icon: 'build' },
    { id: '5', name: 'Carpintería', icon: 'carpenter' },
    { id: '6', name: 'Pintura', icon: 'format_paint' },
    { id: '7', name: 'Mecánica', icon: 'car_crash' },
  ];

  constructor() {}

  public getCategories(): Category[] {
    return this.categories;
  }

  public selectedCategory(): Category {
    return this._selectedCategory;
  }

  public selectCategory(id: IdCategory): Observable<Category> {
    const category = this.categories.find((category) => category.id === id) || this.categories[0];
    this._selectedCategory = category;
    return of(category);
  }

}
