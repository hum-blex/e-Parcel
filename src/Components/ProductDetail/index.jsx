import { useContext } from 'react';
import { ShoppingCartContext} from '../../contexts';
import { Aside } from '../Aside';

const ProductDetail = () => {
  const {
    isProductDetailOpen,
    closeProductDetail,
    productDetail,
  } = ShoppingCartContext;

  return (
    <Aside isOpen={isProductDetailOpen} title="Detail" onClose={closeProductDetail}>
      <figure>
        <img
          className="w-full h-full rounded-lg"
          src={productDetail.image}
          alt={productDetail.title}
        />
      </figure>
      <p className="flex flex-col">
        <span className="font-medium text-2xl mb-2">{productDetail.price}</span>
        <span className="font-medium text-md">{productDetail.title}</span>
        <span className="font-light text-sm">{productDetail.description}</span>
      </p>
    </Aside>
  );
};

export { ProductDetail };
