import { Component, inject, OnInit } from '@angular/core';
import { ChartData, ChartOptions } from 'chart.js';
import { BaseChartDirective } from 'ng2-charts';
import { Category } from '../../models/category.interface';
import { CategoryService } from '../../services/category.service';

@Component({
  selector: 'app-doughnut-chart',
  standalone: true,
  imports: [BaseChartDirective],
  templateUrl: './doughnut-chart.component.html',
  styleUrl: './doughnut-chart.component.scss',
})
export class DoughnutChartComponent {
  public categories: Category[] = [];
  private categoryService = inject(CategoryService);

  public doughnutChartData: ChartData<'doughnut'> = {
    labels: [],
    datasets: [
      {
        data: [],
        backgroundColor: [],
        hoverBackgroundColor: [],
      },
    ],
  };

  ngOnInit(): void {
    this.categoryService.getCategories().subscribe((categories) => {
      this.categories = categories.slice(1);
      this.updateChartData();
    });
  }

  private updateChartData(): void {
    this.doughnutChartData = {
      labels: this.categories.map((category) => category.name),
      datasets: [
        {
          data: this.categories.map(() => Math.floor(Math.random() * 100)),
          backgroundColor: this.getRandomColors(this.categories.length),
          hoverBackgroundColor: this.getRandomColors(this.categories.length),
        },
      ],
    };
  }

  public doughnutChartOptions: ChartOptions<'doughnut'> = {
    responsive: true,
    plugins: {
      legend: {
        title: {
          display: true,
          text: 'Categorías',
        },
      },
      tooltip: {
        callbacks: {
          label: (tooltipItem) => {
            const dataset = tooltipItem.dataset as any;
            const value = dataset.data[tooltipItem.dataIndex];
            return `${dataset.label}: ${value}`;
          },
        },
      },
    },
  };

  public doughnutChartLegend = false;
  public doughnutChartPlugins = [];
  public doughnutChartType: 'doughnut' = 'doughnut';

  private getRandomColors(count: number): string[] {
    const colors = [
      '#FF6384',
      '#36A2EB',
      '#FFCE56',
      '#4BC0C0',
      '#9966FF',
      '#FF9F40',
    ];
    return Array.from({ length: count }, (_, i) => colors[i % colors.length]);
  }
}
