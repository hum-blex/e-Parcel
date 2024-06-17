// import React from 'react';
// import { useShoppingCart } from '../hooks/useShoppingCart';
// import { OrderCard } from '../Components/OrderCard';
// import { useNavigate } from 'react-router-dom';
// import { toast } from 'react-toastify';
// import 'react-toastify/dist/ReactToastify.css';

// const Checkout = () => {
//   const { cartProducts, clearCart, getTotalPrice, handleCheckout, order } = useShoppingCart();
//   const navigate = useNavigate();

//   const handlePlaceOrder = () => {
//     console.log('Current Orders before checkout:', order); // Add this line
//     handleCheckout();
//     console.log('Current Orders after checkout:', order); // Add this line
  
//     toast.success('Order has been placed!', {
//       position: "top-center",
//     });
//     navigate('/profile/order-history');
//   };
  
//   return (
//     <div className="flex flex-col gap-2 py-4 flex-1">
//       <h1 className="text-2xl font-bold mb-4">Checkout</h1>
//       {cartProducts.map((product) => (
//         <OrderCard
//           key={product.id.toString()}
//           id={product.id.toString()}
//           title={product.title}
//           image={product.image}
//           price={product.price}
//           onDelete={() => {}}
//         />
//       ))}
//       <div className="mb-6">
//         <p className="flex justify-between items-center mb-2">
//           <span className="font-light">Total:</span>
//           <span className="font-medium text-2xl">${getTotalPrice(cartProducts)}</span>
//         </p>
//         <div className="flex flex-col items-center">
//           <button
//             className="bg-black py-3 text-white w-60 rounded-lg"
//             onClick={handlePlaceOrder}
//             type="button"
//           >
//             Place Order
//           </button>
//         </div>
//       </div>
//     </div>
//   );
// };

// export default Checkout;

import React from 'react';
import { useShoppingCart } from '../hooks/useShoppingCart';
import { OrderCard } from '../Components/OrderCard';
import { useNavigate } from 'react-router-dom';
import { toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const Checkout = () => {
  const { cartProducts, clearCart, getTotalPrice, handleCheckout, order, handleDelete } = useShoppingCart();
  const navigate = useNavigate();

  const handlePlaceOrder = () => {
    console.log('Current Orders before checkout:', order); // Log current orders before checkout
    handleCheckout();
    console.log('Current Orders after checkout:', order); // Log current orders after checkout

    toast.success('Order has been placed!', {
      position: "top-center",
    });
    navigate('/profile/order-history');
  };

  return (
    <div className="flex flex-col gap-2 py-4 flex-1">
      <h1 className="text-2xl font-bold mb-4">Checkout</h1>
      {cartProducts.map((product) => (
        <OrderCard
          key={product.id.toString()}
          id={product.id.toString()}
          title={product.title}
          image={product.image}
          price={product.price}
          onDelete={() => handleDelete(product.id.toString())} // Add handleDelete for each product
        />
      ))}
      <div className="mb-6">
        <p className="flex justify-between items-center mb-2">
          <span className="font-light">Total:</span>
          <span className="font-medium text-2xl">${getTotalPrice(cartProducts)}</span>
        </p>
        <div className="flex flex-col items-center">
          <button
            className="bg-black py-3 text-white w-60 rounded-lg mb-2"
            onClick={handlePlaceOrder}
            type="button"
          >
            Place Order
          </button>
        </div>
      </div>
    </div>
  );
};

export default Checkout;
