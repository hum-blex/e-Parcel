import React, { useState } from "react";
import { HoveredLink, Menu, MenuItem, ProductItem } from "../ui/navbar-menu";
import { cn } from "../utils/cn";
import Logo from "../../assets/logo-color.png";
import { IoMdSearch } from "react-icons/io";
import { FaShoppingCart } from "react-icons/fa"; // Corrected import for shopping cart icon
import DarkMode from "./DarkMode";
import { Link, useNavigate } from "react-router-dom"; // Updated import to use useNavigate
export function NavbarDemo() {
  return (
    <div className="relative w-full flex items-center justify-center">
      <Navbar className="top-2" />
      <p className="text-black dark:text-white">
        The Navbar will show on top of the page
      </p>
    </div>
  );
}

const Navbar: React.FC<{ className?: string }> = ({ className }) => {
  const [active, setActive] = useState<string | null>(null);
  const [isCartVisible, setIsCartVisible] = useState<boolean>(false);
  const [cartItems, setCartItems] = useState<Array<any>>([]); // Replace any with your cart item type
  const navigate = useNavigate(); // Updated to useNavigate

  const handleCartClick = () => {
    setIsCartVisible(!isCartVisible);
  };

  const goToCheckout = () => {
    navigate('/checkout'); // Updated method to navigate
  };

  return (
    <div className="shadow-md bg-white dark:bg-gray-900 dark:text-white duration-200 relative z-40">
      {/* Upper Navbar */}
      <div className="bg-primary/40 py-2">
        <div className="container flex justify-between items-center">
          <div>
            <a
              href="#"
              className="font-bold text-2xl sm:text-3xl flex gap-2 items-center"
            >
              <img src={Logo} alt="Logo" className="w-10" />
              <Link to="/home">
                Parcel
              </Link>
            </a>
          </div>
          {/* search bar*/}
          <div className="flex justify-between items-center gap-4">
            <div className="relative group hidden sm:block">
              <input
                type="text"
                placeholder="Search"
                className="w-[200px] sm:w-[200px]
                group-hover:w-[300px] transition-all duration-300 rounded-full border border-gray-300 px-2 yp-1 foucs:outline-none focus:border-1 focus:border-primary"
              />
              <IoMdSearch className="text-gray-500 group-hover:text-primary absolute top-1/2 -translate-y-1/2 right-3" />
            </div>
            {/* Cart button */}
            <button
              onClick={handleCartClick}
              className="bg-gradient-to-r from-primary to-secondary transition-all duration-200 text-white py-1 px-4 rounded-full flex items-center gap-3 group"
            >
              <span className="group-hover:block hidden transition-all duration-200">
                Order
              </span>
              <FaShoppingCart className="text-xl text-white drop-shadow-sm cursor-pointer" />
            </button>
            {/* DarkMode Switch */}
            <div>
              <DarkMode />
            </div>
          </div>
        </div>
      </div>
      {/* Cart Details */}
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
      {/* Lower Navbar*/}
      <div
        className={cn(
          "fixed top-16 inset-x-0 max-w-2xl mx-auto z-50",
          className
        )}
      >
        <Menu setActive={setActive}>
          <MenuItem setActive={setActive} active={active} item="Categories">
            <div className="flex flex-col space-y-4 text-sm">
              <HoveredLink href="/clothing">Clothing</HoveredLink>
              <HoveredLink href="/electronics">Electronics</HoveredLink>
              <HoveredLink href="/kitchenware">Kitchen Ware</HoveredLink>
              <HoveredLink href="/furniture">Furniture</HoveredLink>
            </div>
          </MenuItem>
          <MenuItem setActive={setActive} active={active} item="Pricing">
            <div className="flex flex-col space-y-4 text-sm">
              <HoveredLink href="/hobby">Hobby</HoveredLink>
              <HoveredLink href="/individual">Individual</HoveredLink>
              <HoveredLink href="/team">Team</HoveredLink>
              <HoveredLink href="/enterprise">Enterprise</HoveredLink>
            </div>
          </MenuItem>
          <MenuItem setActive={setActive} active={active} item="Profile">
            <div className="flex flex-col space-y-4 text-sm">
              <HoveredLink href="/profile">My Profile</HoveredLink>
            </div>
          </MenuItem>
          <Link to="./login">
            <MenuItem setActive={setActive} active={active} item="Login/Signup">
              Login/Signup
            </MenuItem>
          </Link>
        </Menu>
      </div>
    </div>
  );
};

export default Navbar;
