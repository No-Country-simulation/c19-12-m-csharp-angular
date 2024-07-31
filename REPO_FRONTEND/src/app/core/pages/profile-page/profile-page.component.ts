import { Component } from '@angular/core';
import { HeaderComponent } from '../../../shared/components/header/header.component';
import { MaterialModule } from '../../../material/material.module';
import { CommonModule } from '@angular/common';
import { CardService } from '../../services/card.service';

import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { Card, IdCard } from '../../models/card.interface';
import { CategoriesToStringPipe } from '../../pipes/categories-to-string.pipe';
import { Job } from '../../models/job.interface';
import { JobService } from '../../services/job.service';
import { FooterComponent } from '../../../shared/components/footer/footer.component';
import { MatDialog } from '@angular/material/dialog';
import { JobDialogComponent } from '../../components/job-dialog/job-dialog.component';

@Component({
  selector: 'app-profile-page',
  standalone: true,
  imports: [
    CommonModule,
    MaterialModule,
    HeaderComponent,
    RouterModule,
    CategoriesToStringPipe,
    FooterComponent,
  ],
  templateUrl: './profile-page.component.html',
  styleUrl: './profile-page.component.scss',
})
export class ProfilePageComponent {
  public card: Card | null = null;
  public jobs: Job[] = [];

  constructor(
    private cardService: CardService,
    private jobService: JobService,
    private route: ActivatedRoute,
    private router: Router,
    private dialog: MatDialog
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
    const jobs = this.jobService.getJobsByUserId(id).subscribe(
      (response) => {
        this.jobs = response;
      },
      (error) => {
        console.error('Error loading jobs:', error);
      }
    );
  }

  openDialog(job: any): void {
    this.dialog.open(JobDialogComponent, {
      width: '400px',
      data: job,
    });
  }
}
