import React, { createContext, useContext, useState } from 'react';

interface Item {
  id: number;
  name: string;
  quantity: number;
  price: number;
}

const CartContext = createContext<{
  cartItems: Item[];
  addToCart: (item: Item) => void;
}>({
  cartItems: [],
  addToCart: (item: Item) => {}
});

export const CartProvider: React.FC<{children: React.ReactNode}> = ({ children }) => {
  const [cartItems, setCartItems] = useState<Item[]>([]);

  const addToCart = (item: Item) => {
    setCartItems(prevItems => [...prevItems, item]);
  };

  return (
    <CartContext.Provider value={{ cartItems, addToCart }}>
      {children}
    </CartContext.Provider>
  );
};

export const useCart = () => useContext(CartContext);