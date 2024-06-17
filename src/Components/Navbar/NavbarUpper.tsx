import React from "react";
import { Link, useNavigate } from "react-router-dom";
import { IoMdSearch } from "react-icons/io";
import { FaShoppingCart } from "react-icons/fa";
import Logo from "../../assets/logo-color.png";
import { useCart } from '../../contexts/CartContext';
import ThemeToggleButton from './ThemeToggleButton';

const NavbarUpper: React.FC = () => {
  const { cartItems } = useCart();
  const [isCartVisible, setIsCartVisible] = React.useState(false);
  const navigate = useNavigate();

  const handleCartClick = () => {
    setIsCartVisible(!isCartVisible);
  };

  const goToCheckout = () => {
    navigate('/checkout');
  };

  return (
    <div className="bg-[#a972f7] dark:bg-[#6a00ff] py-2">
      <div className="container flex justify-between items-center">
        <div>
          <Link to="/" className="font-bold text-2xl sm:text-3xl flex gap-2 items-center">
            <img src={Logo} alt="Logo" className="w-10" />
            Parcel
          </Link>
        </div>
        <div className="flex justify-between items-center gap-4">
          <div className="relative group hidden sm:block">
            <input
              type="text"
              placeholder="Search"
              className="w-[200px] sm:w-[200px] group-hover:w-[300px] transition-all duration-300 rounded-full border border-gray-300 px-2 py-1 focus:outline-none focus:border-1 focus:border-primary"
            />
            <IoMdSearch className="text-gray-500 group-hover:text-primary absolute top-1/2 -translate-y-1/2 right-3" />
          </div>
          <button
            onClick={handleCartClick}
            className="bg-gradient-to-r from-primary to-secondary transition-all duration-200 text-white py-1 px-4 rounded-full flex items-center gap-3 group"
          >
            <span className="group-hover:block hidden transition-all duration-200">
              Order
            </span>
            <FaShoppingCart className="text-xl text-white drop-shadow-sm cursor-pointer" />
          </button>
          <div>
            <ThemeToggleButton />
          </div>
        </div>
      </div>
      {isCartVisible && (
        <div className="absolute right-0 top-full mt-2 p-4 bg-white shadow-lg rounded-lg">
          {cartItems.length > 0 ? (
            <ul>
              {cartItems.map((item, index) => (
                <li key={index}>{item.name} - Quantity: {item.quantity}</li>
              ))}
            </ul>
          ) : (
            <p>No items in the cart.</p>
          )}
          <button onClick={goToCheckout} className="mt-4 bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded">
            Move to Checkout
          </button>
        </div>
      )}
    </div>
  );
};

export default NavbarUpper;
