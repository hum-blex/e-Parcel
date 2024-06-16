// import { XMarkIcon } from "@heroicons/react/24/solid"
// import { useShoppingCart } from "../../hooks/useShoppingCart";

// interface OrderCardProps {
//   id: string;
//   title: string;
//   image: string;
//   price: number;
//   onDelete: (id: string) => void;
// }

// const OrderCard = (props: OrderCardProps) => {
//   const { 
//     id,
//     title,
//     image,
//     price,
//     onDelete
//   } = props;

//   return (
//     <div className="flex justify-between items-center">
//       <div className="flex items-center gap-2">
//         <figure className="w-20 h-20">
//           <img className="w-full h-full rounded-lg object-cover" src={image} alt={title} />
//         </figure>
//         <p className="text-sm font-light">{title}</p>
//       </div>
//       <div className="flex items-center gap-2">
//         <p className="text-lg font-medium">{price}</p>
//         {onDelete && <XMarkIcon
//           className="h-6 w-6 text-black cursor-pointer"
//           onClick={() => onDelete(id)}
//         />}
//       </div>
//     </div>
//   )
// }

// export { OrderCard } 

import { XMarkIcon } from "@heroicons/react/24/solid";


interface OrderCardProps {
  id: string;
  title: string;
  image: string;
  price: number;
  onDelete: (id: string) => void;
}

const OrderCard = (props: OrderCardProps) => {
  const { id, title, image, price, onDelete } = props;

  console.log('OrderCard id:', id); // Add this line
  console.log('OrderCard onDelete:', onDelete); // Add this line

  const handleDeleteClick = () => {
    console.log('Delete button clicked for id:', id); // Add this line
    onDelete(id);
  };

  return (
    <div className="flex items-center gap-2">
      <img src={image} alt={title} className="w-12 h-12 object-cover" />
      <div className="flex-1">
        <p>{title}</p>
        <p>${price}</p>
      </div>
      <XMarkIcon
        className="h-6 w-6 cursor-pointer"
        onClick={handleDeleteClick}
      />
    </div>
  );
};

export { OrderCard };