import { useContext } from 'react';
import { ShoppingCartContext } from '../../contexts';
import { Aside } from '../Aside';
import { OrderCard } from '../OrderCard';
import { useShoppingCart } from '../../hooks/useShoppingCart';
import { Link } from 'react-router-dom';

interface Product {
  id: number;
  title: string;
  image: string;
  price: number;
}

const CheckoutSideMenu = () => {
  const { getTotalPrice, handleCheckout, handleDelete } = useShoppingCart(); // Call useShoppingCart at the top level, before any conditions or early returns

  const shoppingCartContext = useContext(ShoppingCartContext);

  if (!shoppingCartContext) {
    console.error('CheckoutSideMenu must be used within a ShoppingCartProvider');
    return null; // This return does not affect hooks since it's after all hooks are called
  }

  const {
    isCheckoutSideMenu,
    closeCheckoutSideMenu,
    cartProducts,
  } = shoppingCartContext;

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
        <Link to="/my-orders/last">
          <button
            className="bg-black py-3 text-white w-full rounded-lg"
            onClick={handleCheckout}
            type="button"
          >
            Checkout
          </button>
        </Link>
      </div>
    </Aside>
  );
};

export { CheckoutSideMenu };
