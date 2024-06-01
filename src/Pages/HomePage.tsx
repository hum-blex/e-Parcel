import React from 'react';
import Navbar from "../Components/Navbar/Navbar";
import { ProductCard } from '../Components/ProductCard';

export const HomePage = () => {
  const handleAddToCart = () => {
    console.log('Product added to cart!');
    // Implement cart logic here
  };

  return (
    <div>
      <Navbar />
      <div style={{ display: 'flex', flexDirection: 'row', flexWrap: 'wrap' }}>
        <ProductCard productName="Product 1" productPrice={29.99} onAddToCart={handleAddToCart} />
        <ProductCard productName="Product 2" productPrice={39.99} onAddToCart={handleAddToCart} />
        <ProductCard productName="Product 3" productPrice={49.99} onAddToCart={handleAddToCart} />
        {/* Add more ProductCards as needed */}
      </div>
    </div>
  );
};

