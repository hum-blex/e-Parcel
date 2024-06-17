

// import { useContext, useEffect } from "react";
// import { ShoppingCartContext } from "../contexts";

// const useShoppingCart = () => {
//   const {
//     cartProducts,
//     setCartProducts,
//     openCheckoutSideMenu,
//     closeCheckoutSideMenu,
//     setCounter,
//     openProductDetail,
//     closeProductDetail,
//     setProductDetail,
//     order,
//     setOrder
//   } = useContext(ShoppingCartContext);

//   // Add useEffect to log cartProducts whenever it changes
//   useEffect(() => {
//     console.log('Updated cartProducts:', cartProducts);
//   }, [cartProducts]);

//   const handleDelete = (strid) => {
//     const id = parseInt(strid);
//     console.log('Deleting product with id:', id);
//     console.log('Current cart products before delete:', cartProducts);

//     const filteredProducts = [...cartProducts].filter(product => product.id !== id);
//     console.log('Filtered products:', filteredProducts);

//     setCartProducts(filteredProducts); // Update cart products
//     setCounter(prev => {
//       console.log('Previous counter value:', prev);
//       return prev - 1;
//     });

//     // Log after state update
//     setTimeout(() => {
//       console.log('Updated cart products after delete:', filteredProducts);
//     }, 0);
//   };

//   const handleCheckout = () => {
//     const date = new Date();
//     const orderToAdd = {
//       date: `${date.getDate()}/${date.getMonth() + 1}/${date.getFullYear()}`,
//       products: cartProducts,
//       totalProducts: cartProducts.length,
//       totalPrice: getTotalPrice(cartProducts)
//     };

//     setOrder([...order, orderToAdd]);
//     setCartProducts([]);
//     setCounter(0);
//   };

//   const showProduct = (data) => {
//     setProductDetail(data);
//     openProductDetail();
//     closeCheckoutSideMenu();
//   };

//   const addProductToCart = (event, data) => {
//     if (event && event.stopPropagation) {
//       event.stopPropagation();
//     }
//     console.log('Adding product to cart:', data);

//     setCounter((prev) => prev + 1);
//     setCartProducts(prevProducts => {
//       const newProducts = [...prevProducts, data];
//       console.log('New cart products:', newProducts);
//       return newProducts;
//     });

//     closeProductDetail();
//     openCheckoutSideMenu();
//   };

//   const getTotalPrice = (products) => {
//     return products.reduce((sum, product) => sum + product.price, 0);
//   };

//   return {
//     handleDelete,
//     handleCheckout,
//     showProduct,
//     addProductToCart,
//     cartProducts,
//     getTotalPrice
//   };
// };

// export { useShoppingCart };

import { useContext, useEffect } from "react";
import { ShoppingCartContext } from "../contexts";
import { Product, ProductDetail, Order } from "../types/types";



const useShoppingCart = () => {
  const {
    cartProducts,
    setCartProducts,
    openCheckoutSideMenu,
    closeCheckoutSideMenu,
    setCounter,
    openProductDetail,
    closeProductDetail,
    setProductDetail,
    order,
    setOrder
  } = useContext(ShoppingCartContext);

  useEffect(() => {
    // console.log('Updated cartProducts:', cartProducts);
  }, [cartProducts]);

  const handleDelete = (strid) => {
    const id = parseInt(strid);
    // console.log('Deleting product with id:', id);
    // console.log('Current cart products before delete:', cartProducts);

    const filteredProducts = cartProducts.filter(product => product.id !== id);
    // console.log('Filtered products:', filteredProducts);

    setCartProducts(filteredProducts);
    setCounter(prev => prev - 1);

    setTimeout(() => {
      // console.log('Updated cart products after delete:', filteredProducts);
    }, 0);
  };

  const handleCheckout = () => {
    const date = new Date();
    const orderToAdd = {
      date: `${date.getDate()}/${date.getMonth() + 1}/${date.getFullYear()}`,
      products: cartProducts,
      totalProducts: cartProducts.length,
      totalPrice: getTotalPrice(cartProducts)
    };

    setOrder([...order, orderToAdd]);
    setCartProducts([]);
    // setCounter(0);
  };

  const showProduct = (data) => {
    setProductDetail(data);
    openProductDetail();
    closeCheckoutSideMenu();
  };

  const addProductToCart = (event, data) => {
    if (event && event.stopPropagation) {
      event.stopPropagation();
    }
    // console.log('Adding product to cart:', data);

    setCounter(prev => prev + 1);
    setCartProducts(prevProducts => {
      const newProducts = [...prevProducts, data];
      // console.log('New cart products:', newProducts);
      return newProducts;
    });

    closeProductDetail();
    openCheckoutSideMenu();
  };

  const addToCart = (product) => {
    setCounter(prev => prev + 1);
    setCartProducts(prevProducts => [...prevProducts, product]);
  };

  const addMultipleToCart = (products) => {
    setCounter(prev => prev + products.length);
    setCartProducts(prevProducts => [...prevProducts, ...products]);
  };

  const clearCart = () => {
    setCartProducts([]);
    setCounter(0);
  };

  const getTotalPrice = (products) => {
    return products.reduce((sum, product) => sum + product.price, 0);
  };

  return {
    handleDelete,
    handleCheckout,
    showProduct,
    addProductToCart,
    addToCart,
    addMultipleToCart,
    clearCart,
    cartProducts,
    getTotalPrice,
    order // Return the order state
  };
};

export { useShoppingCart };
