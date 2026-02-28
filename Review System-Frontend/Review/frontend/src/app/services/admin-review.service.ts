import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { PendingReview, ReviewModeration } from '../models/review';

@Injectable({ providedIn: 'root' })
export class AdminReviewService {
  private apiUrl = `${environment.apiUrl}/admin/reviews`;

  constructor(private http: HttpClient) { }

  getPendingReviews(): Observable<PendingReview[]> {
    return this.http.get<PendingReview[]>(`${this.apiUrl}/pending`);
  }

  moderateReview(dto: ReviewModeration): Observable<any> {
    return this.http.put(`${this.apiUrl}/moderate`, dto, { responseType: 'text' });
  }
}
