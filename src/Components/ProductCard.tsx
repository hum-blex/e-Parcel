import React from 'react';

interface ProductCardProps {
  productName: string;
  productPrice: number;
  onAddToCart: () => void;
}

export const ProductCard: React.FC<ProductCardProps> = ({ productName, productPrice, onAddToCart }) => {
  return (
    <div style={{ border: '1px solid gray', padding: '10px', margin: '10px', marginTop: '100px'}}>
      <h3>{productName}</h3>
      {/* <img src={productImage} alt={productName} /> */}
      <p>${productPrice}</p>
      <button onClick={onAddToCart}>Add to Cart</button>
    </div>
  );
};