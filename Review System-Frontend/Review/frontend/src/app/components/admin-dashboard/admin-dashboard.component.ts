import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminReviewService } from '../../services/admin-review.service';
import { PendingReview } from '../../models/review';

@Component({
  selector: 'app-admin-dashboard',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './admin-dashboard.component.html',
  styleUrl: './admin-dashboard.component.css'
})
export class AdminDashboardComponent implements OnInit {
  pendingReviews: PendingReview[] = [];
  loading = true;

  constructor(private adminReviewService: AdminReviewService) { }

  ngOnInit(): void {
    this.loadPendingReviews();
  }

  loadPendingReviews() {
    this.adminReviewService.getPendingReviews().subscribe({
      next: (data) => {
        this.pendingReviews = data;
        this.loading = false;
      },
      error: () => this.loading = false
    });
  }

  moderate(reviewId: number, status: 'Approved' | 'Rejected') {
    this.adminReviewService.moderateReview({ reviewId, status }).subscribe({
      next: () => {
        // Remove from list
        this.pendingReviews = this.pendingReviews.filter(r => r.reviewId !== reviewId);
      },
      error: () => alert('Failed to change status')
    });
  }

  getStars(rating: number): number[] {
    return Array(Math.round(rating)).fill(0);
  }
}
