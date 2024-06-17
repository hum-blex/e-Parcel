

export interface Product {
    id: number;
    title: string;
    category: string;
    price: number;
    description: string;
    image: string;
    rating: {
      rate: number;
      count: number;
    };
  }
  
  export interface ProductDetail {
    title: string;
    price: string;
    description: string;
    image: string;
  }
  
  export interface Order {
    date: string;
    totalProducts: number;
    totalPrice: number;
    products: Product[];
  }
  