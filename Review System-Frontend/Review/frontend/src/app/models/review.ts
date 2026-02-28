export interface CreateReview {
    productId: number;
    rating: number;
    comment: string;
}

export interface ReviewDisplay {
    userName: string;
    rating: number;
    comment: string;
}

export interface PendingReview {
    reviewId: number;
    productName: string;
    userName: string;
    rating: number;
    comment: string;
}

export interface ReviewModeration {
    reviewId: number;
    status: string; // 'Approved' | 'Rejected'
}
