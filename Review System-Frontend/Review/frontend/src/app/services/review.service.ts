import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { CreateReview } from '../models/review';

@Injectable({ providedIn: 'root' })
export class ReviewService {
  private apiUrl = `${environment.apiUrl}/reviews`;

  constructor(private http: HttpClient) { }

  submitReview(dto: CreateReview): Observable<any> {
    return this.http.post(this.apiUrl, dto, { responseType: 'text' });
  }
}
