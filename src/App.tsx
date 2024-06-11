import React from 'react';
import Navbar from './Components/Navbar/Navbar';
import { ShoppingCartProvider } from './contexts';
import { CheckoutSideMenu } from './Components/CheckoutSideMenu';
import { CartProvider } from "./contexts/CartContext";
import { useTheme } from './contexts/themeContext'; // Import useTheme with correct casing

function App() {
  const { theme } = useTheme();

  // Dynamically import theme CSS
  React.useEffect(() => {
    if (theme === 'dark') {
      require('./styles/dark-theme.css');
    } else {
      require('./styles/light-theme.css');
    }
  }, [theme]);

  return (
    <ShoppingCartProvider>
      <div className={`App ${theme}`}> {/* Apply the theme class */}
        <Navbar />
        <CheckoutSideMenu />
      </div>
    </ShoppingCartProvider>
  );
}

export default App;
