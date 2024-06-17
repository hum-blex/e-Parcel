// import { useContext } from 'react';
// import { ShoppingCartContext } from '../../contexts';
// import { Aside } from '../Aside';
// import { OrderCard } from '../OrderCard';
// import { useShoppingCart } from '../../hooks/useShoppingCart';
// import { useWishlist } from '../../contexts/wishlistContext';
// import { Link } from 'react-router-dom';

// interface Product {
//   id: number;
//   title: string;
//   category: string;
//   price: number;
//   image: string;
//   rating: {
//     rate: number;
//     count: number;
//   }
// }

// const CheckoutSideMenu = () => {
//   const { getTotalPrice, handleCheckout, handleDelete } = useShoppingCart();
//   const shoppingCartContext = useContext(ShoppingCartContext);
//   const { addToWishlist } = useWishlist();

//   if (!shoppingCartContext) {
//     console.error('CheckoutSideMenu must be used within a ShoppingCartProvider');
//     return null;
//   }

//   const {
//     isCheckoutSideMenu,
//     closeCheckoutSideMenu,
//     cartProducts,
//   } = shoppingCartContext;

//   return (
//     <Aside
//       isOpen={isCheckoutSideMenu}
//       title="My order"
//       onClose={closeCheckoutSideMenu}
//     >
//       <div className="flex flex-col gap-2 py-4 flex-1">
//         {cartProducts.map((product: Product) => (
//           <OrderCard
//             key={product.id.toString()}
//             id={product.id.toString()}
//             title={product.title}
//             image={product.image}
//             price={product.price}
//             onDelete={handleDelete}
//           />
//         ))}
//       </div>
//       <div className="mb-6">
//         <p className="flex justify-between items-center mb-2">
//           <span className="font-light">Total:</span>
//           <span className="font-medium text-2xl">{getTotalPrice(cartProducts)}</span>
//         </p>
//         <Link to="/checkout">
//           <button
//             className="bg-black py-3 text-white w-full rounded-lg"
//             onClick={handleCheckout}
//             type="button"
//           >
//             Checkout
//           </button>
//         </Link>
//         <button
//           className="bg-blue-500 py-3 text-white w-full rounded-lg mt-2"
//           onClick={() => {
//             cartProducts.forEach(product => addToWishlist(product));
//           }}
//           type="button"
//         >
//           Add All to Wishlist
//         </button>
//         <Link to="/profile/wishlist">
//           <button
//             className="bg-green-500 py-3 text-white w-full rounded-lg mt-2"
//             type="button"
//           >
//             View Wishlist
//           </button>
//         </Link>
//       </div>
//     </Aside>
//   );
// };

// export { CheckoutSideMenu };

// import { useContext } from 'react';
// import { ShoppingCartContext } from '../../contexts';
// import { Aside } from '../Aside';
// import { OrderCard } from '../OrderCard';
// import { useShoppingCart } from '../../hooks/useShoppingCart';
// import { useWishlist } from '../../contexts/wishlistContext';
// import { Link, useNavigate } from 'react-router-dom';

// interface Product {
//   id: number;
//   title: string;
//   category: string;
//   price: number;
//   image: string;
//   rating: {
//     rate: number;
//     count: number;
//   }
// }

// const CheckoutSideMenu = () => {
//   const { getTotalPrice, handleCheckout, handleDelete, cartProducts } = useShoppingCart();
//   const {addMultipleToCart} = useShoppingCart();
//   const {clearWishlist} = useWishlist();
//   const shoppingCartContext = useContext(ShoppingCartContext);
//   const { addToWishlist } = useWishlist();
//   const navigate = useNavigate();

//   if (!shoppingCartContext) {
//     console.error('CheckoutSideMenu must be used within a ShoppingCartProvider');
//     return null;
//   }

//   const {
//     isCheckoutSideMenu,
//     closeCheckoutSideMenu,
//   } = shoppingCartContext;

//   const handleCheckoutClick = () => {
//     addMultipleToCart(cartProducts);
//     // clearWishlist(); // Clear the wishlist
//     navigate('/profile/checkout');
//   };

//   return (
//     <Aside
//       isOpen={isCheckoutSideMenu}
//       title="My order"
//       onClose={closeCheckoutSideMenu}
//     >
//       <div className="flex flex-col gap-2 py-4 flex-1">
//         {cartProducts.map((product: Product) => (
//           <OrderCard
//             key={product.id.toString()}
//             id={product.id.toString()}
//             title={product.title}
//             image={product.image}
//             price={product.price}
//             onDelete={handleDelete}
//           />
//         ))}
//       </div>
//       <div className="mb-6">
//         <p className="flex justify-between items-center mb-2">
//           <span className="font-light">Total:</span>
//           <span className="font-medium text-2xl">{getTotalPrice(cartProducts)}</span>
//         </p>
//         <button
//           className="bg-black py-3 text-white w-full rounded-lg"
//           onClick={handleCheckoutClick}
//           type="button"
//         >
//           Checkout
//         </button>
//         <button
//           className="bg-blue-500 py-3 text-white w-full rounded-lg mt-2"
//           onClick={() => {
//             cartProducts.forEach(product => addToWishlist(product));
//           }}
//           type="button"
//         >
//           Add All to Wishlist
//         </button>
//         <Link to="/profile/wishlist">
//           <button
//             className="bg-green-500 py-3 text-white w-full rounded-lg mt-2"
//             type="button"
//           >
//             View Wishlist
//           </button>
//         </Link>
//       </div>
//     </Aside>
//   );
// };

// export { CheckoutSideMenu };

import { useContext } from 'react';
import { ShoppingCartContext } from '../../contexts';
import { Aside } from '../Aside';
import { OrderCard } from '../OrderCard';
import { useShoppingCart } from '../../hooks/useShoppingCart';
import { useWishlist } from '../../contexts/wishlistContext';
import { Link, useNavigate } from 'react-router-dom';

interface Product {
  id: number;
  title: string;
  category: string;
  price: number;
  image: string;
  rating: {
    rate: number;
    count: number;
  }
}

const CheckoutSideMenu = () => {
  const { getTotalPrice, handleCheckout, handleDelete, cartProducts, clearCart } = useShoppingCart();
  const { addMultipleToCart } = useShoppingCart();
  const { clearWishlist } = useWishlist();
  const shoppingCartContext = useContext(ShoppingCartContext);
  const { addToWishlist } = useWishlist();
  const navigate = useNavigate();

  if (!shoppingCartContext) {
    console.error('CheckoutSideMenu must be used within a ShoppingCartProvider');
    return null;
  }

  const { isCheckoutSideMenu, closeCheckoutSideMenu } = shoppingCartContext;

  const handleCheckoutClick = () => {
    clearCart();
    addMultipleToCart(cartProducts);
    navigate('/profile/checkout');
  };

  return (
    <Aside
      isOpen={isCheckoutSideMenu}
      title="My order"
      onClose={closeCheckoutSideMenu}
    >
      <div className="flex flex-col gap-2 py-4 flex-1">
        {cartProducts.map((product: Product) => (
          <OrderCard
            key={product.id.toString()}
            id={product.id.toString()}
            title={product.title}
            image={product.image}
            price={product.price}
            onDelete={handleDelete}
          />
        ))}
      </div>
      <div className="mb-6">
        <p className="flex justify-between items-center mb-2">
          <span className="font-light">Total:</span>
          <span className="font-medium text-2xl">{getTotalPrice(cartProducts)}</span>
        </p>
        <button
          className="bg-black py-3 text-white w-full rounded-lg"
          onClick={handleCheckoutClick}
          type="button"
        >
          Checkout
        </button>
        <button
          className="bg-blue-500 py-3 text-white w-full rounded-lg mt-2"
          onClick={() => {
            cartProducts.forEach(product => addToWishlist(product));
          }}
          type="button"
        >
          Add All to Wishlist
        </button>
        <Link to="/profile/wishlist">
          <button
            className="bg-green-500 py-3 text-white w-full rounded-lg mt-2"
            type="button"
          >
            View Wishlist
          </button>
        </Link>
      </div>
    </Aside>
  );
};

export { CheckoutSideMenu };

