export interface ProductList {
  id: number;
  name: string;
  price: number;
  averageRating: number;
  totalReviews: number;
}

export interface ProductDetails {
  id: number;
  name: string;
  description: string;
  price: number;
  averageRating: number;
  totalReviews: number;
  reviews: {
    userName: string;
    rating: number;
    comment: string;
  }[];
}
