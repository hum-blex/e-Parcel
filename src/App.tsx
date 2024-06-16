import React from 'react';
import Navbar from './Components/Navbar/Navbar';
import { ShoppingCartProvider } from './contexts';
import { CheckoutSideMenu } from './Components/CheckoutSideMenu';
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

  // List of paths where the Navbar should not be displayed
  const hideNavbarPaths = ['/login', '/signup', '/profile'];

  // Check if the current path is in the list of paths where the Navbar should be hidden
  const hideNavbar = hideNavbarPaths.includes(location.pathname);

  return (
    <ShoppingCartProvider>
      <div className={`App ${theme}`}>
        {!hideNavbar && <Navbar />}
        <Outlet />
        {/* <CheckoutSideMenu /> */}
      </div>
    </ShoppingCartProvider>
  );
}

export default App;

