// import React from 'react';
// import { useShoppingCart } from '../../hooks/useShoppingCart';

// const OrderHistory = () => {
//   const { order } = useShoppingCart();

//   return (
//     <div className="flex flex-col gap-2 py-4 flex-1">
//       <h1 className="text-2xl font-bold mb-4">Order History</h1>
//       {order.map((orderItem, index) => (
//         <div key={index} className="mb-4 p-4 border rounded">
//           <p className="font-bold">Date: {orderItem.date}</p>
//           <p>Total Products: {orderItem.totalProducts}</p>
//           <p>Total Price: ${orderItem.totalPrice}</p>
//           <div className="mt-2">
//             {orderItem.products.map(product => (
//               <div key={product.id.toString()} className="flex justify-between mb-2">
//                 <p>{product.title}</p>
//                 <p>${product.price}</p>
//               </div>
//             ))}
//           </div>
//         </div>
//       ))}
//     </div>
//   );
// };

// export default OrderHistory;
import React from 'react';
import { useShoppingCart } from '../../hooks/useShoppingCart';

const OrderHistory = () => {
  const { order } = useShoppingCart();
  console.log('Order History:', order); // Add this line

  return (
    <div className="flex flex-col gap-2 py-4 flex-1">
      <h1 className="text-2xl font-bold mb-4">Order History</h1>
      {order.map((orderItem, index) => (
        <div key={index} className="mb-4 p-4 border rounded">
          <p className="font-bold">Date: {orderItem.date}</p>
          <p>Total Products: {orderItem.totalProducts}</p>
          <p>Total Price: ${orderItem.totalPrice}</p>
          <div className="mt-2">
            {orderItem.products.map(product => (
              <div key={product.id.toString()} className="flex justify-between mb-2">
                <p>{product.title}</p>
                <p>${product.price}</p>
              </div>
            ))}
          </div>
        </div>
      ))}
    </div>
  );
};

export default OrderHistory;
