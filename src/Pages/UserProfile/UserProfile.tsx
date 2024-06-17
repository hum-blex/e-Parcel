import React from 'react';
import { Routes, Route } from 'react-router-dom';
import Sidebar from '../../Components/Sidebar/Sidebar';
import ProfileSetting from '../ProfileSetting/ProfileSetting';
import Wishlist from '../Wishlist/Wishlist';
import OrderHistory from '../OrderHistory/OrderHistory';
import Checkout from "../Checkout";


const UserProfile = () => {
  return (
    <div className="flex">
      <Sidebar />
      <div className="flex-1 p-6">
        <Routes>
          <Route path="" element={<ProfileSetting />} />
          <Route path="profile-setting" element={<ProfileSetting />} />
          <Route path="wishlist" element={<Wishlist />} />
          <Route path="checkout" element={<Checkout />} />
          <Route path="order-history" element={<OrderHistory />} />
        </Routes>
      </div>
    </div>
  );
};

export default UserProfile;