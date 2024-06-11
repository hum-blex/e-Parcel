import { createContext, useEffect, useState, ReactNode, FC } from 'react';
import { apiUrl } from '../api';
import { useLocalStorage } from '../hooks/useLocalStorage';

interface ProductDetail {
  title: string;
  price: string;
  description: string;
  image: string;
}

interface Product {
  id: number;
  title: string;
  category: string;
  price: number;
  description: string;
  image: string;
}

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
  order: Product[];
  setOrder: (products: Product[]) => void;
  items: Product[];
  setItems: (items: Product[]) => void;
  searchValue: string;
  setSearchValue: (value: string) => void;
  filteredItems: Product[];
  setFilteredItems: (items: Product[]) => void;
  filteredItemsByTitle: () => Product[];
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
  order: [],
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
  const [order, setOrder] = useState<Product[]>([]);

  const openProductDetail = () => setIsProductDetailOpen(true);
  const closeProductDetail = () => setIsProductDetailOpen(false);
  const openCheckoutSideMenu = () => setIsCheckoutSideMenu(true);
  const closeCheckoutSideMenu = () => setIsCheckoutSideMenu(false);

  useEffect(() => {
    (async () => {
      try {
        const response = await fetch(apiUrl);

        if (response.status !== 200) return;

        const data = await response.json();
        setItems(data);
      } catch (error) {
        console.log('An error has occurred');
      }
    })();
  }, []);

  const [items, setItems] = useState<Product[]>([]);
  const [filteredItems, setFilteredItems] = useState<Product[]>([]);
  const [searchValue, setSearchValue] = useState('');
  const [searchCategory, setSearchCategory] = useState('');

  const filteredItemsByTitle = (): Product[] => {
    const condition = (item: { title: string }) => item.title.toLowerCase().includes(searchValue.toLowerCase());
    const categoryCondition = (item: { category: string }) => item.category.toLowerCase().includes(searchCategory?.toLowerCase());

    return items.filter(item => (searchCategory === '' ? condition(item) : condition(item) && categoryCondition(item)));
  };

  useEffect(() => {
    setFilteredItems(filteredItemsByTitle());
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
