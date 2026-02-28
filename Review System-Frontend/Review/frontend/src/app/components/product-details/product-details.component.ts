import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ProductService } from '../../services/product.service';
import { ReviewService } from '../../services/review.service';
import { AuthService } from '../../services/auth.service';
import { ProductDetails } from '../../models/product';

@Component({
  selector: 'app-product-details',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './product-details.component.html',
  styleUrl: './product-details.component.css'
})
export class ProductDetailsComponent implements OnInit {
  product: ProductDetails | null = null;
  loading: boolean = true;

  // New Review Form
  newRating: number = 5;
  newComment: string = '';
  submitting: boolean = false;
  submitMessage: string = '';

  constructor(
    private route: ActivatedRoute,
    private productService: ProductService,
    private reviewService: ReviewService,
    public authService: AuthService
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.loadProduct(+id);
    }
  }

  loadProduct(id: number): void {
    this.productService.getProductById(id).subscribe({
      next: (data) => {
        this.product = data;
        this.loading = false;
      },
      error: () => this.loading = false
    });
  }

  setRating(val: number) {
    this.newRating = val;
  }

  submitReview() {
    if (!this.product || this.newRating < 1 || this.newRating > 5 || !this.newComment.trim()) return;

    this.submitting = true;
    this.reviewService.submitReview({
      productId: this.product.id,
      rating: this.newRating,
      comment: this.newComment
    }).subscribe({
      next: (msg) => {
        this.submitMessage = "Review submitted! It will appear once approved by an admin.";
        this.submitting = false;
        this.newComment = '';
      },
      error: (err) => {
        this.submitMessage = "Failed: You must have directly purchased this product or haven't reviewed it yet.";
        this.submitting = false;
      }
    });
  }

  getStars(rating: number): number[] {
    return Array(Math.round(rating)).fill(0);
  }
}
