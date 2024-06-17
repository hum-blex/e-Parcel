import React from "react";
import { Link } from "react-router-dom";
import { FaUser, FaHeart, FaHistory, FaCartPlus } from "react-icons/fa";

type Props = {};

const Sidebar = (props: Props) => {
  return (
    <nav className="py-4 px-6 w-64 bg-white shadow-xl flex-col md:relative absolute top-0 bottom-0 left-0 transform transition-transform duration-300 ease-in-out md:translate-x-0 -translate-x-full">
      <div className="flex-col min-h-full px-0 flex items-center justify-between w-full mx-auto overflow-y-auto">
        <div className="flex-col items-stretch mt-4 overflow-y-auto h-auto z-40 w-full">
          <div className="flex-col min-w-full list-none">
            <Link
              to="profile-setting"
              className="flex min-w-full text-blueGray-500 text-xs uppercase font-bold pt-1 pb-4 no-underline"
            >
              <FaUser className="mr-3" />
              <h6>Profile Setting</h6>
            </Link>
            <Link
              to="wishlist"
              className="flex min-w-full text-blueGray-500 text-xs uppercase font-bold pt-1 pb-4 no-underline"
            >
              <FaHeart className="mr-3" />
              <h6>Wishlist</h6>
            </Link>
            <Link
              to="checkout"
              className="flex min-w-full text-blueGray-500 text-xs uppercase font-bold pt-1 pb-4 no-underline"
            >
              <FaCartPlus className="mr-3" />
              <h6>Checkout</h6>
            </Link>
            <Link
              to="order-history"
              className="flex min-w-full text-blueGray-500 text-xs uppercase font-bold pt-1 pb-4 no-underline"
            >
              <FaHistory className="mr-3" />
              <h6>Order History</h6>
            </Link>
          </div>
        </div>
      </div>
    </nav>
  );
};

export default Sidebar;