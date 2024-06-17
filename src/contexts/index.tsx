// import React, { createContext, useEffect, useState, ReactNode, FC } from 'react';
// import { apiUrl } from '../api';
// import { useLocalStorage } from '../hooks/useLocalStorage';

// interface ProductDetail {
//   title: string;
//   price: string;
//   description: string;
//   image: string;
// }

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


// interface ShoppingCartContextType {
//   counter: number;
//   setCounter: (value: number) => void;
//   isProductDetailOpen: boolean;
//   openProductDetail: () => void;
//   closeProductDetail: () => void;
//   productDetail: ProductDetail;
//   setProductDetail: (product: ProductDetail) => void;
//   cartProducts: Product[];
//   setCartProducts: (products: Product[]) => void;
//   isCheckoutSideMenu: boolean;
//   openCheckoutSideMenu: () => void;
//   closeCheckoutSideMenu: () => void;
//   order: Product[];
//   setOrder: (products: Product[]) => void;
//   items: Product[];
//   setItems: (items: Product[]) => void;
//   searchValue: string;
//   setSearchValue: (value: string) => void;
//   filteredItems: Product[];
//   setFilteredItems: (items: Product[]) => void;
//   filteredItemsByTitle: () => Product[];
//   searchCategory: string;
//   setSearchCategory: (value: string) => void;
//   updateCategoryPath: (path: string) => void;
//   account: any; // Replace with actual type if available
//   signIn: () => void;
//   signOut: () => void;
//   isSignIn: boolean;
// }

// interface ShoppingCartProviderProps {
//   children: ReactNode;
// }

// export const ShoppingCartContext = createContext<ShoppingCartContextType>({
//   counter: 0,
//   setCounter: () => {},
//   isProductDetailOpen: false,
//   openProductDetail: () => {},
//   closeProductDetail: () => {},
//   productDetail: {
//     title: '',
//     price: '',
//     description: '',
//     image: ''
//   },
//   setProductDetail: () => {},
//   cartProducts: [],
//   setCartProducts: () => {},
//   isCheckoutSideMenu: false,
//   openCheckoutSideMenu: () => {},
//   closeCheckoutSideMenu: () => {},
//   order: [],
//   setOrder: () => {},
//   items: [],
//   setItems: () => {},
//   searchValue: '',
//   setSearchValue: () => {},
//   filteredItems: [],
//   setFilteredItems: () => {},
//   filteredItemsByTitle: () => [],
//   searchCategory: '',
//   setSearchCategory: () => {},
//   updateCategoryPath: () => {},
//   account: null,
//   signIn: () => {},
//   signOut: () => {},
//   isSignIn: false
// });

// export const ShoppingCartProvider: FC<ShoppingCartProviderProps> = ({ children }) => {
//   const [counter, setCounter] = useState(0);
//   const [isProductDetailOpen, setIsProductDetailOpen] = useState(false);
//   const [isCheckoutSideMenu, setIsCheckoutSideMenu] = useState(false);
//   const [productDetail, setProductDetail] = useState<ProductDetail>({
//     title: '',
//     price: '',
//     description: '',
//     image: ''
//   });
//   const [cartProducts, setCartProducts] = useState<Product[]>([]);
//   const [order, setOrder] = useState<Product[]>([]);
//   const [items, setItems] = useState<Product[]>([]);
//   const [filteredItems, setFilteredItems] = useState<Product[]>([]);
//   const [searchValue, setSearchValue] = useState('');
//   const [searchCategory, setSearchCategory] = useState('');

//   const openProductDetail = () => setIsProductDetailOpen(true);
//   const closeProductDetail = () => setIsProductDetailOpen(false);
//   const openCheckoutSideMenu = () => setIsCheckoutSideMenu(true);
//   const closeCheckoutSideMenu = () => setIsCheckoutSideMenu(false);

//   useEffect(() => {
//     const fetchItems = async () => {
//       try {
//         const response = await fetch(apiUrl);

//         if (response.status !== 200) return;

//         const data = await response.json();
//         console.log('Fetched Data:', data);
//         setItems(data);
//         console.log('Initial state of items:', data); 
//       } catch (error) {
//         console.log('An error has occurred');
//       }
//     };

//     fetchItems();
//   }, []);

//   const filteredItemsByTitle = (): Product[] => {
//     const condition = (item: { title: string }) => item.title.toLowerCase().includes(searchValue.toLowerCase());
//     const categoryCondition = (item: { category: string }) => item.category.toLowerCase().includes(searchCategory?.toLowerCase());

//     return items.filter(item => (searchCategory === '' ? condition(item) : condition(item) && categoryCondition(item)));
//   };

//   useEffect(() => {
//     setFilteredItems(filteredItemsByTitle());
//   }, [items, searchValue, searchCategory]);

//   const updateCategoryPath = (categoryPath: string) => {
//     const category = categoryPath.substring(1);
//     setSearchCategory(category);
//   };

//   const {
//     account,
//     signIn,
//     signOut,
//     isSignIn
//   } = useLocalStorage();

//   return (
//     <ShoppingCartContext.Provider value={{
//       counter,
//       setCounter,
//       isProductDetailOpen,
//       openProductDetail,
//       closeProductDetail,
//       productDetail,
//       setProductDetail,
//       cartProducts,
//       setCartProducts,
//       isCheckoutSideMenu,
//       openCheckoutSideMenu,
//       closeCheckoutSideMenu,
//       order,
//       setOrder,
//       items,
//       setItems,
//       searchValue,
//       setSearchValue,
//       filteredItems,
//       setFilteredItems,
//       filteredItemsByTitle,
//       searchCategory,
//       setSearchCategory,
//       updateCategoryPath,
//       account,
//       signIn,
//       signOut,
//       isSignIn
//     }}>
//       {children}
//     </ShoppingCartContext.Provider>
//   );
// };

import React, { createContext, useEffect, useState, ReactNode, FC } from 'react';
import { apiUrl } from '../api';
import { useLocalStorage } from '../hooks/useLocalStorage';
import { Product, ProductDetail, Order } from '../types/types';  // Import types

interface ShoppingCartContextType {
  counter: number;
  setCounter: (value: number) => void;
  isProductDetailOpen: boolean;
  openProductDetail: () => void;
  closeProductDetail: () => void;
  productDetail: ProductDetail;
  setProductDetail: (product: ProductDetail) => void;
  cartProducts: Product[];
  setCartProducts: (products: Product[]) => void;
  isCheckoutSideMenu: boolean;
  openCheckoutSideMenu: () => void;
  closeCheckoutSideMenu: () => void;
  order: Order[];  // Update the type here
  setOrder: (orders: Order[]) => void;  // Update the type here
  items: Product[];
  setItems: (items: Product[]) => void;
  searchValue: string;
  setSearchValue: (value: string) => void;
  filteredItems: Product[];
  setFilteredItems: (items: Product[]) => void;
  filteredItemsByTitle: (items: Product[], searchValue: string, searchCategory: string) => Product[];
  searchCategory: string;
  setSearchCategory: (value: string) => void;
  updateCategoryPath: (path: string) => void;
  account: any; // Replace with actual type if available
  signIn: () => void;
  signOut: () => void;
  isSignIn: boolean;
}

interface ShoppingCartProviderProps {
  children: ReactNode;
}

const filteredItemsByTitle = (items: Product[], searchValue: string, searchCategory: string): Product[] => {
  // console.log('Filtering items with:', searchValue, searchCategory);

  const condition = (item: Product) => item.title.toLowerCase().includes(searchValue.toLowerCase());
  const categoryCondition = (item: Product) => item.category.toLowerCase().includes(searchCategory?.toLowerCase());

  const filteredItems = items.filter(item => {
    const titleMatch = condition(item);
    const categoryMatch = categoryCondition(item);

    // console.log('Item:', item.title, 'Title Match:', titleMatch, 'Category Match:', categoryMatch);

    return titleMatch || (searchCategory !== '' && categoryMatch);
  });

  // console.log('Filtered Items:', filteredItems);

  return filteredItems;
};

export const ShoppingCartContext = createContext<ShoppingCartContextType>({
  counter: 0,
  setCounter: () => {},
  isProductDetailOpen: false,
  openProductDetail: () => {},
  closeProductDetail: () => {},
  productDetail: {
    title: '',
    price: '',
    description: '',
    image: ''
  },
  setProductDetail: () => {},
  cartProducts: [],
  setCartProducts: () => {},
  isCheckoutSideMenu: false,
  openCheckoutSideMenu: () => {},
  closeCheckoutSideMenu: () => {},
  order: [],  // Initialize with an empty array
  setOrder: () => {},
  items: [],
  setItems: () => {},
  searchValue: '',
  setSearchValue: () => {},
  filteredItems: [],
  setFilteredItems: () => {},
  filteredItemsByTitle: () => [],
  searchCategory: '',
  setSearchCategory: () => {},
  updateCategoryPath: () => {},
  account: null,
  signIn: () => {},
  signOut: () => {},
  isSignIn: false
});

export const ShoppingCartProvider: FC<ShoppingCartProviderProps> = ({ children }) => {
  const [counter, setCounter] = useState(0);
  const [isProductDetailOpen, setIsProductDetailOpen] = useState(false);
  const [isCheckoutSideMenu, setIsCheckoutSideMenu] = useState(false);
  const [productDetail, setProductDetail] = useState<ProductDetail>({
    title: '',
    price: '',
    description: '',
    image: ''
  });
  const [cartProducts, setCartProducts] = useState<Product[]>([]);
  const [order, setOrder] = useState<Order[]>([]);  // Update the state type
  const [items, setItems] = useState<Product[]>([]);
  const [filteredItems, setFilteredItems] = useState<Product[]>([]);
  const [searchValue, setSearchValue] = useState('');
  const [searchCategory, setSearchCategory] = useState('');

  const openProductDetail = () => setIsProductDetailOpen(true);
  const closeProductDetail = () => setIsProductDetailOpen(false);
  const openCheckoutSideMenu = () => setIsCheckoutSideMenu(true);
  const closeCheckoutSideMenu = () => setIsCheckoutSideMenu(false);

  useEffect(() => {
    const fetchItems = async () => {
      try {
        const response = await fetch(apiUrl);

        if (response.status !== 200) return;

        const data = await response.json();
        // console.log('Fetched Data:', data);
        setItems(data);
        // console.log('Initial state of items:', data);
      } catch (error) {
        // console.log('An error has occurred');
      }
    };

    fetchItems();
  }, []);

  useEffect(() => {
    const filtered = filteredItemsByTitle(items, searchValue, searchCategory);
    setFilteredItems(filtered);
  }, [items, searchValue, searchCategory]);

  const updateCategoryPath = (categoryPath: string) => {
    const category = categoryPath.substring(1);
    setSearchCategory(category);
  };

  const {
    account,
    signIn,
    signOut,
    isSignIn
  } = useLocalStorage();

  return (
    <ShoppingCartContext.Provider value={{
      counter,
      setCounter,
      isProductDetailOpen,
      openProductDetail,
      closeProductDetail,
      productDetail,
      setProductDetail,
      cartProducts,
      setCartProducts,
      isCheckoutSideMenu,
      openCheckoutSideMenu,
      closeCheckoutSideMenu,
      order,
      setOrder,
      items,
      setItems,
      searchValue,
      setSearchValue,
      filteredItems,
      setFilteredItems,
      filteredItemsByTitle,
      searchCategory,
      setSearchCategory,
      updateCategoryPath,
      account,
      signIn,
      signOut,
      isSignIn
    }}>
      {children}
    </ShoppingCartContext.Provider>
  );
};
