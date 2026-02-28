import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { ProductList, ProductDetails } from '../models/product';

@Injectable({ providedIn: 'root' })
export class ProductService {
  private apiUrl = `${environment.apiUrl}/products`;

  constructor(private http: HttpClient) { }

  getAllProducts(): Observable<ProductList[]> {
    return this.http.get<ProductList[]>(this.apiUrl);
  }

  getProductById(id: number): Observable<ProductDetails> {
    return this.http.get<ProductDetails>(`${this.apiUrl}/${id}`);
  }
}
