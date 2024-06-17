// import { FC } from 'react';
// import { CheckIcon, PlusIcon } from '@heroicons/react/24/solid';
// import { useShoppingCart } from '../../hooks/useShoppingCart';

// interface ProductData {
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

// interface CardProps {
//   data: ProductData;
// }

// const Card: FC<CardProps> = ({ data }) => {
//   const {
//     cartProducts,
//     addProductToCart,
//     showProduct,
//   } = useShoppingCart();
//   const renderIcon = () => {
//     const isInCart = cartProducts.some((product: ProductData) => product.id === data.id);

//     const commonClasses = 'absolute top-0 right-0 flex justify-center items-center w-6 h-6 rounded-full m-2 p-1';

//     if (isInCart) {
//       return (
//         <div className={`${commonClasses} bg-black`}>
//           <CheckIcon className="h-6 w-6 text-white" />
//         </div>
//       );
//     } else {
//       return (
//         <div
//           className={`${commonClasses} bg-white`}
//           onClick={(e) => {
//             e.stopPropagation();
//             addProductToCart(data);
//           }}
//         >
//           <PlusIcon className="h-6 w-6 text-black" />
//         </div>
//       );
//     }
//   };

//   return (
//     <div
//       className="bg-white cursor-pointer w-56 h-60 rounded-lg"
//       onClick={() => showProduct(data)}
//     >
//       <figure className="relative mb-2 w-full h-4/5">
//         <span className="absolute bottom-0 left-0 bg-white/60 rounded-lg text-black text-xs m-2 px-3 py-0.5">
//           {data.category}
//         </span>
//         <img
//           className="w-full h-full object-cover rounded-lg"
//           src={data.image}
//           alt={data.title}
//         />
//         {renderIcon()}
//       </figure>
//       <p className="flex justify-between">
//         <span className="text-sm font-light">{data.title}</span>
//         <span className="text-lg font-medium">${data.price}</span>
//       </p>
//     </div>
//   );
// };

// export { Card };

// import { FC } from 'react';
// import { CheckIcon, PlusIcon } from '@heroicons/react/24/solid';
// import { useShoppingCart } from '../../hooks/useShoppingCart';

// interface ProductData {
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

// interface CardProps {
//   data: ProductData;
// }

// const Card: FC<CardProps> = ({ data }) => {
//   const {
//     cartProducts,
//     addProductToCart,
//     showProduct,
//   } = useShoppingCart();

//   const renderIcon = () => {
//     const isInCart = cartProducts.some((product: ProductData) => product.id === data.id);

//     const commonClasses = 'absolute top-0 right-0 flex justify-center items-center w-6 h-6 rounded-full m-2 p-1';

//     if (isInCart) {
//       return (
//         <div className={`${commonClasses} bg-black`}>
//           <CheckIcon className="h-6 w-6 text-white" />
//         </div>
//       );
//     } else {
//       return (
//         <div
//           className={`${commonClasses} bg-white`}
//           onClick={(e) => {
//             e.stopPropagation();
//             addProductToCart(e, data);
//           }}
//         >
//           <PlusIcon className="h-6 w-6 text-black" />
//         </div>
//       );
//     }
//   };

//   return (
//     <div
//       className="bg-white cursor-pointer w-56 h-60 rounded-lg"
//       onClick={() => showProduct(data)}
//     >
//       <figure className="relative mb-2 w-full h-4/5">
//         <span className="absolute bottom-0 left-0 bg-white/60 rounded-lg text-black text-xs m-2 px-3 py-0.5">
//           {data.category}
//         </span>
//         <img
//           className="w-full h-full object-cover rounded-lg"
//           src={data.image}
//           alt={data.title}
//         />
//         {renderIcon()}
//       </figure>
//       <p className="flex justify-between">
//         <span className="text-sm font-light">{data.title}</span>
//         <span className="text-lg font-medium">${data.price}</span>
//       </p>
//     </div>
//   );
// };

// export { Card };

import { FC, MouseEvent } from 'react';
import { CheckIcon, PlusIcon } from '@heroicons/react/24/solid';
import { useShoppingCart } from '../../hooks/useShoppingCart';

interface ProductData {
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

interface CardProps {
  data: ProductData;
}

const Card: FC<CardProps> = ({ data }) => {
  const { cartProducts, addProductToCart, showProduct } = useShoppingCart();

  const renderIcon = () => {
    const isInCart = cartProducts.some((product: ProductData) => product.id === data.id);

    const commonClasses = 'absolute top-0 right-0 flex justify-center items-center w-6 h-6 rounded-full m-2 p-1';

    if (isInCart) {
      return (
        <div className={`${commonClasses} bg-black`}>
          <CheckIcon className="h-6 w-6 text-white" />
        </div>
      );
    } else {
      return (
        <div
          className={`${commonClasses} bg-white`}
          onClick={(e: MouseEvent<HTMLDivElement>) => {
            e.stopPropagation();
            addProductToCart(e, data);
          }}
        >
          <PlusIcon className="h-6 w-6 text-black" />
        </div>
      );
    }
  };

  return (
    <div
      className="relative bg-white cursor-pointer w-56 h-60 rounded-lg overflow-hidden shadow-md transition-transform transform hover:scale-105"
      onClick={() => showProduct(data)}
    >
      <figure className="relative w-full h-full">
        <img
          className="w-full h-full object-cover rounded-lg"
          src={data.image}
          alt={data.title}
        />
        <div className="absolute inset-0 bg-black bg-opacity-50 opacity-0 hover:opacity-100 transition-opacity duration-300 flex flex-col justify-end p-4">
          <span className="text-white text-xs">{data.category}</span>
          <p className="text-white text-lg font-medium mt-2">{data.title}</p>
          <p className="text-white text-sm">${data.price}</p>
        </div>
        {renderIcon()}
      </figure>
    </div>
  );
};

export { Card };
