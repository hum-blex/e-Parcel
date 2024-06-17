// import React from 'react';
// import Navbar from './Components/Navbar/Navbar';
// import { ShoppingCartProvider } from './contexts';
// import { WishlistProvider } from './contexts/wishlistContext';
// import { CheckoutSideMenu } from './Components/CheckoutSideMenu';
// import { useTheme } from './contexts/themeContext';
// import { Outlet, useLocation } from 'react-router-dom';

// function App() {
//   const { theme } = useTheme();
//   const location = useLocation();

//   // Dynamically import theme CSS
//   React.useEffect(() => {
//     if (theme === 'dark') {
//       require('./styles/dark-theme.css');
//     } else {
//       require('./styles/light-theme.css');
//     }
//   }, [theme]);

//   // List of paths where the Navbar should not be displayed
//   const hideNavbarPaths = ['/login', '/signup', ];

//   // Check if the current path is in the list of paths where the Navbar should be hidden
//   const hideNavbar = hideNavbarPaths.includes(location.pathname);

//   return (
//     <ShoppingCartProvider>
//       <WishlistProvider>
//       <div className={`App ${theme}`}>
//         {!hideNavbar && <Navbar />}
//         <Outlet />
//         {/* <CheckoutSideMenu /> */}
//       </div>
//       </WishlistProvider>
//     </ShoppingCartProvider>
//   );
// }

// export default App;

import React from 'react';
import Navbar from './Components/Navbar/Navbar';
import NavbarUpper from './Components/Navbar/NavbarUpper';
import { ShoppingCartProvider } from './contexts';
import { WishlistProvider } from './contexts/wishlistContext';
import { useTheme } from './contexts/themeContext';
import { Outlet, useLocation } from 'react-router-dom';

function App() {
  const { theme } = useTheme();
  const location = useLocation();

  // Dynamically import theme CSS
  React.useEffect(() => {
    if (theme === 'dark') {
      require('./styles/dark-theme.css');
    } else {
      require('./styles/light-theme.css');
    }
  }, [theme]);

  // List of paths where only the upper part of the Navbar should be displayed
  const upperNavbarOnlyPaths = ['/profile','/profile/profile-setting', '/profile/wishlist', '/profile/checkout', '/profile/order-history'];
  const fullNavbarPaths = ['', '/' ,'/user'];

  // Check if the current path is in the list of paths
  const showUpperNavbarOnly = upperNavbarOnlyPaths.includes(location.pathname);
  const showFullNavbar = fullNavbarPaths.includes(location.pathname);

  return (
    <ShoppingCartProvider>
      <WishlistProvider>
      <div className={`App ${theme}`}>
        {showFullNavbar && <Navbar />}
        {showUpperNavbarOnly && !showFullNavbar && <NavbarUpper />}
        <Outlet />
      </div>
      </WishlistProvider>
    </ShoppingCartProvider>
  );
}

export default App;
