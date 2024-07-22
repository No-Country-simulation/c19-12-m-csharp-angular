import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FooterComponent } from '../../../shared/components/footer/footer.component';
import { HeaderComponent } from '../../../shared/components/header/header.component';
import { MaterialModule } from '../../../material/material.module';
import { FiltersComponent } from '../../../shared/components/filters/filters.component';

@Component({
  selector: 'app-index',
  standalone: true,
  imports: [
    CommonModule,
    HeaderComponent,
    FooterComponent,
    MaterialModule,
    FiltersComponent,
  ],
  templateUrl: './index.component.html',
  styleUrl: './index.component.scss',
})
export class IndexComponent {}
