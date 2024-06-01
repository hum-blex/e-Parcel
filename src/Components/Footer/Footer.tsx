import React from "react";
import { Link } from "react-router-dom";
import { useSelector } from "react-redux";

const Footer: React.FC = () => {
 const loginState = useSelector((state: any) => state.auth.isLoggedIn);

 return (
   <footer className="footer footer-center p-10 bg-base-200 text-base-content rounded mt-10 max-md:px-0">
     <nav className="grid grid-flow-col max-sm:grid-flow-row gap-4">
       <Link
         to="/"
         className="link link-hover text-2xl max-md:text-xl text-accent-content"
         onClick={() => window.scrollTo(0, 0)}
       >
         Home
       </Link>
       <Link
         to="/services"
         className="link link-hover text-2xl max-md:text-xl text-accent-content"
         onClick={() => window.scrollTo(0, 0)}
       >
         Services
       </Link>
       <Link
         to="/products"
         className="link link-hover text-2xl max-md:text-xl text-accent-content"
         onClick={() => window.scrollTo(0, 0)}
       >
         Products
       </Link>
       <Link
         to="/pricing"
         className="link link-hover text-2xl max-md:text-xl text-accent-content"
         onClick={() => window.scrollTo(0, 0)}
       >
         Pricing
       </Link>
       {!loginState && (
         <>
           <Link
             to="/login"
             className="link link-hover text-2xl max-md:text-xl text-accent-content"
             onClick={() => window.scrollTo(0, 0)}
           >
             Login
           </Link>
           <Link
             to="/signup"
             className="link link-hover text-2xl max-md:text-xl text-accent-content"
             onClick={() => window.scrollTo(0, 0)}
           >
             SignUp
           </Link>
         </>
       )}
     </nav>
     <aside>
       <p className="text-2xl max-sm:text-sm text-accent-content">
         Copyright © 2024 - All right reserved by Parcel
       </p>
     </aside>
   </footer>
 );
};

export default Footer;