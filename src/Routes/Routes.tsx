import { createBrowserRouter } from "react-router-dom";
import App from "../App";
import HomePage from "../Pages/HomePage";
import LoginPage from "../Pages/login";
import SignUpPage from "../Pages/signup";
import UserProfile from "../Pages/UserProfile/UserProfile";

export const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
    children: [
      { path: "", element: <HomePage /> },
      { path: "login", element: <LoginPage /> },
      { path: "SignUp", element: <SignUpPage /> },
      
      {
        path: "profile",
        element: <UserProfile />,
        children: [
          { path: "", element: <UserProfile /> },
          { path: "profile-setting", element: <UserProfile /> },
          { path: "wishlist", element: <UserProfile /> },
          { path: "order-history", element: <UserProfile /> }
        ]
      }
    ]
  }
]);

export {};