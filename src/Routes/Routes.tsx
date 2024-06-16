import { createBrowserRouter } from "react-router-dom";
import App from "../App";
import HomePage from "../Pages/HomePage";
import LoginPage from "../Pages/login";
import SignUpPage from "../Pages/signup";
import UserProfile from "../Pages/UserProfile/UserProfile";
import { Dashboard } from "../Pages/Dashboard";
import ProfileSetting from "../Pages/ProfileSetting/ProfileSetting";
import Wishlist from "../Pages/Wishlist/Wishlist";
import OrderHistory from "../Pages/OrderHistory/OrderHistory";
import NotFoundPage from '../Pages/NotFound';

export const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
    children: [
      { path: "", element: <HomePage /> },
      { path: "login", element: <LoginPage /> },
      { path: "signup", element: <SignUpPage /> },
      
      {
        path: "user",
        element: <Dashboard />  
      },
      {
        path: "profile",
        element: <UserProfile />,
        children: [
          { path: "", element: <UserProfile /> },
          { path: "profile-setting", element: <UserProfile /> },
          { path: "wishlist", element: <UserProfile /> },
          { path: "order-history", element: <UserProfile /> }
        ]
      },
      { path: "*", element: <NotFoundPage /> } 
    ]
  }
]);

export {};