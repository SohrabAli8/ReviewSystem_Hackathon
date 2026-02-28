import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ProductService } from '../../services/product.service';
import { ProductList } from '../../models/product';

@Component({
  selector: 'app-product-catalog',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './product-catalog.component.html',
  styleUrl: './product-catalog.component.css'
})
export class ProductCatalogComponent implements OnInit {
  products: ProductList[] = [];
  loading: boolean = true;

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.productService.getAllProducts().subscribe({
      next: (data) => {
        this.products = data;
        this.loading = false;
      },
      error: () => {
        this.loading = false;
        console.error('Failed to fetch products');
      }
    });
  }

  getStars(rating: number): number[] {
    return Array(Math.round(rating)).fill(0);
  }
}
