import React from 'react';
import ReactDOM from 'react-dom/client';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import './index.css';
import App from './App';
import Login from './Pages/login';
import Signup from './Pages/signup';
import HomePage from './Pages/HomePage';
import ProductDetails from './Components/Product/ProductItem'; // Assuming you have a ProductDetails page
import UserProfile from './Pages/UserProfile/UserProfile'; // Assuming you have a UserProfile page
import NotFound from './Pages/NotFound'; // A generic 404 page
import { ShoppingCartProvider } from './contexts';
import { CheckoutSideMenu } from './Components/CheckoutSideMenu';
import { ThemeProvider } from './contexts/themeContext'; // Correct the casing
import reportWebVitals from './reportWebVitals';

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);
root.render(
  <React.StrictMode>
    <BrowserRouter>
      <ThemeProvider>
        <Routes>
          <Route path="/" element={<App />} />
          <Route path="/login" element={<Login />} />
          <Route path="/signup" element={<Signup />} />
          <Route path="/home" element={<HomePage />} />
          <Route path="/product/details" element={<ProductDetails />} />
          <Route path="/user/profile" element={<UserProfile />} />
          <Route path="*" element={<NotFound />} />
        </Routes>
      </ThemeProvider>
    </BrowserRouter>
  </React.StrictMode>
);

reportWebVitals();
