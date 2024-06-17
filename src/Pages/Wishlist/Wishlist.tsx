// import React from 'react';
// import { useWishlist } from '../../contexts/wishlistContext';
// import { OrderCard } from '../../Components/OrderCard';
// import { Link } from 'react-router-dom';

// const Wishlist = () => {
//   const { wishlistProducts, removeFromWishlist, clearWishlist } = useWishlist();

//   const handleDelete = (id: string) => {
//     removeFromWishlist(Number(id));
//   };

//   const getTotalPrice = () => {
//     return wishlistProducts.reduce((total, product) => total + product.price, 0);
//   };

//   return (
//     <div className="flex flex-col gap-2 py-4 flex-1">
//       <h1 className="text-2xl font-bold mb-4">Wishlist</h1>
//       {wishlistProducts.map((product) => (
//         <OrderCard
//           key={product.id.toString()}
//           id={product.id.toString()}
//           title={product.title}
//           image={product.image}
//           price={product.price}
//           onDelete={handleDelete}
//         />
//       ))}
//       <div className="mb-6">
//         <p className="flex justify-between items-center mb-2">
//           <span className="font-light">Total:</span>
//           <span className="font-medium text-2xl">{getTotalPrice()}</span>
//         </p>
//         <Link to="/checkout">
//           <button
//             className="bg-black py-3 text-white w-300 rounded-lg"
//             type="button"
//           >
//             Checkout
//           </button>
//         </Link>
//         <button
//           className="bg-red-500 py-3 text-white w-300 rounded-lg mt-2"
//           onClick={clearWishlist}
//           type="button"
//         >
//           Clear Wishlist
//         </button>
//       </div>
//     </div>
//   );
// };

// export default Wishlist;

// import React from 'react';
// import { useWishlist } from '../../contexts/wishlistContext';
// import { useShoppingCart } from '../../hooks/useShoppingCart';
// import { OrderCard } from '../../Components/OrderCard';
// import { Link, useNavigate } from 'react-router-dom';

// const Wishlist = () => {
//   const { wishlistProducts, removeFromWishlist, clearWishlist } = useWishlist();
//   const { addMultipleToCart } = useShoppingCart();
//   const navigate = useNavigate();

//   const handleDelete = (id: string) => {
//     removeFromWishlist(Number(id));
//   };

//   const handleCheckoutClick = () => {
//     addMultipleToCart(wishlistProducts);
//     clearWishlist(); // Clear the wishlist
//     navigate('/profile/checkout');
//   };
//   const getTotalPrice = () => {
//     return wishlistProducts.reduce((total, product) => total + product.price, 0);
//   };

//   return (
//     <div className="flex flex-col gap-2 py-4 flex-1">
//       <h1 className="text-2xl font-bold mb-4">Wishlist</h1>
//       {wishlistProducts.map((product) => (
//         <OrderCard
//           key={product.id.toString()}
//           id={product.id.toString()}
//           title={product.title}
//           image={product.image}
//           price={product.price}
//           onDelete={handleDelete}
//         />
//       ))}
//       <div className="mb-6">
//         <p className="flex justify-between items-center mb-2">
//           <span className="font-light">Total:</span>
//           <span className="font-medium text-2xl">{getTotalPrice()}</span>
//         </p>
//         <button
//           className="bg-black py-3 text-white w-300 rounded-lg"
//           onClick={handleCheckoutClick}
//           type="button"
//         >
//           Checkout
//         </button>
//         <button
//           className="bg-red-500 py-3 text-white w-300 rounded-lg mt-2"
//           onClick={clearWishlist}
//           type="button"
//         >
//           Clear Wishlist
//         </button>
//       </div>
//     </div>
//   );
// };

// export default Wishlist;

// const Wishlist = () => {
//   const { wishlistProducts, removeFromWishlist, clearWishlist } = useWishlist();
//   const { addMultipleToCart, clearCart } = useShoppingCart();
//   const navigate = useNavigate();

//   const handleDelete = (id: string) => {
//     removeFromWishlist(Number(id));
//   };

//   const handleCheckoutClick = () => {
//     clearCart();
//     addMultipleToCart(wishlistProducts);
//     clearWishlist();
//     navigate('/profile/checkout');
//   };

//   const getTotalPrice = () => {
//     return wishlistProducts.reduce((total, product) => total + product.price, 0);
//   };

//   return (
//     <div className="flex flex-col gap-2 py-4 flex-1">
//       <h1 className="text-2xl font-bold mb-4">Wishlist</h1>
//       {wishlistProducts.map((product) => (
//         <OrderCard
//           key={product.id.toString()}
//           id={product.id.toString()}
//           title={product.title}
//           image={product.image}
//           price={product.price}
//           onDelete={handleDelete}
//         />
//       ))}
//       <div className="mb-6">
//         <p className="flex justify-between items-center mb-2">
//           <span className="font-light">Total:</span>
//           <span className="font-medium text-2xl">{getTotalPrice()}</span>
//         </p>
//         <button
//           className="bg-black py-3 text-white w-300 rounded-lg"
//           onClick={handleCheckoutClick}
//           type="button"
//         >
//           Checkout
//         </button>
//         <button
//           className="bg-red-500 py-3 text-white w-300 rounded-lg mt-2"
//           onClick={clearWishlist}
//           type="button"
//         >
//           Clear Wishlist
//         </button>
//       </div>
//     </div>
//   );
// };

// export default Wishlist;

import React from 'react';
import { useWishlist } from '../../contexts/wishlistContext';
import { useShoppingCart } from '../../hooks/useShoppingCart';
import { OrderCard } from '../../Components/OrderCard';
import { Link, useNavigate } from 'react-router-dom';

const Wishlist = () => {
  const { wishlistProducts, removeFromWishlist, clearWishlist } = useWishlist();
  const { addMultipleToCart, clearCart } = useShoppingCart();
  const navigate = useNavigate();

  const handleDelete = (id: string) => {
    removeFromWishlist(Number(id));
  };

  const handleCheckoutClick = () => {
    clearCart();
    addMultipleToCart(wishlistProducts);
    clearWishlist();
    navigate('/profile/checkout');
  };

  const getTotalPrice = () => {
    return wishlistProducts.reduce((total, product) => total + product.price, 0);
  };

  return (
    <div className="flex flex-col gap-2 py-4 flex-1">
      <h1 className="text-2xl font-bold mb-4">Wishlist</h1>
      {wishlistProducts.map((product) => (
        <OrderCard
          key={product.id.toString()}
          id={product.id.toString()}
          title={product.title}
          image={product.image}
          price={product.price}
          onDelete={handleDelete}
        />
      ))}
      <div className="mb-6">
        <p className="flex justify-between items-center mb-2">
          <span className="font-light">Total:</span>
          <span className="font-medium text-2xl">{getTotalPrice()}</span>
        </p>
        <div className="flex flex-col items-center">
          <button
            className="bg-black py-3 text-white w-60 rounded-lg mb-2"
            onClick={handleCheckoutClick}
            type="button"
          >
            Checkout
          </button>
          <button
            className="bg-red-500 py-3 text-white w-60 rounded-lg"
            onClick={clearWishlist}
            type="button"
          >
            Clear Wishlist
          </button>
        </div>
      </div>
    </div>
  );
};

export default Wishlist;
