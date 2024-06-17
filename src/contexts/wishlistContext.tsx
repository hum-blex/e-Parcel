// import React, { createContext, useContext, useEffect, useState, ReactNode, FC } from 'react';
// import { apiUrl } from '../api';

// interface Product {
//   id: number;
//   title: string;
//   category: string;
//   price: number;
//   description: string;
//   image: string;
//   rating: {
//     rate: number;
//     count: number;
//   };
// }

// interface WishlistContextType {
//   wishlistProducts: Product[];
//   setWishlistProducts: (products: Product[]) => void;
//   addToWishlist: (product: Product) => void;
//   removeFromWishlist: (productId: number) => void;
//   clearWishlist: () => void;
//   items: Product[];
//   setItems: (items: Product[]) => void;
//   fetchItems: () => void;
// }

// interface WishlistProviderProps {
//   children: ReactNode;
// }

// const WishlistContext = createContext<WishlistContextType | undefined>(undefined);

// export const WishlistProvider: FC<WishlistProviderProps> = ({ children }) => {
//   const [wishlistProducts, setWishlistProducts] = useState<Product[]>([]);
//   const [items, setItems] = useState<Product[]>([]);

//   const addToWishlist = (product: Product) => {
//     setWishlistProducts((prevWishlist) => [...prevWishlist, product]);
//   };

//   const removeFromWishlist = (productId: number) => {
//     setWishlistProducts((prevWishlist) => prevWishlist.filter(p => p.id !== productId));
//   };

//   const clearWishlist = () => {
//     setWishlistProducts([]);
//   };

//   const fetchItems = async () => {
//     try {
//       const response = await fetch(apiUrl);

//       if (response.status !== 200) return;

//       const data = await response.json();
//       setItems(data);
//     } catch (error) {
//       console.log('An error has occurred');
//     }
//   };

//   useEffect(() => {
//     fetchItems();
//   }, []);

//   return (
//     <WishlistContext.Provider value={{
//       wishlistProducts,
//       setWishlistProducts,
//       addToWishlist,
//       removeFromWishlist,
//       clearWishlist,
//       items,
//       setItems,
//       fetchItems,
//     }}>
//       {children}
//     </WishlistContext.Provider>
//   );
// };

// // Custom hook to use the Wishlist context
// export const useWishlist = (): WishlistContextType => {
//   const context = useContext(WishlistContext);
//   if (!context) {
//     throw new Error('useWishlist must be used within a WishlistProvider');
//   }
//   return context;
// };

import React, { createContext, useContext, useEffect, useState, ReactNode, FC } from 'react';
import { apiUrl } from '../api';
import { Product } from '../types/types';  // Import type

interface WishlistContextType {
  wishlistProducts: Product[];
  setWishlistProducts: (products: Product[]) => void;
  addToWishlist: (product: Product) => void;
  removeFromWishlist: (productId: number) => void;
  clearWishlist: () => void;
  items: Product[];
  setItems: (items: Product[]) => void;
  fetchItems: () => void;
}

interface WishlistProviderProps {
  children: ReactNode;
}

const WishlistContext = createContext<WishlistContextType | undefined>(undefined);

export const WishlistProvider: FC<WishlistProviderProps> = ({ children }) => {
  const [wishlistProducts, setWishlistProducts] = useState<Product[]>([]);
  const [items, setItems] = useState<Product[]>([]);

  const addToWishlist = (product: Product) => {
    setWishlistProducts((prevWishlist) => [...prevWishlist, product]);
  };

  const removeFromWishlist = (productId: number) => {
    setWishlistProducts((prevWishlist) => prevWishlist.filter(p => p.id !== productId));
  };

  const clearWishlist = () => {
    setWishlistProducts([]);
  };

  const fetchItems = async () => {
    try {
      const response = await fetch(apiUrl);

      if (response.status !== 200) return;

      const data = await response.json();
      setItems(data);
    } catch (error) {
      console.log('An error has occurred');
    }
  };

  useEffect(() => {
    fetchItems();
  }, []);

  return (
    <WishlistContext.Provider value={{
      wishlistProducts,
      setWishlistProducts,
      addToWishlist,
      removeFromWishlist,
      clearWishlist,
      items,
      setItems,
      fetchItems
    }}>
      {children}
    </WishlistContext.Provider>
  );
};

export const useWishlist = (): WishlistContextType => {
  const context = useContext(WishlistContext);
  if (context === undefined) {
    throw new Error('useWishlist must be used within a WishlistProvider');
  }
  return context;
};
