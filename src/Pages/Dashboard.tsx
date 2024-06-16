// import React, { useContext, useEffect } from "react";
// import { Outlet } from "react-router-dom"; // Import Outlet from react-router-dom
// import { Card } from "../Components/Card/Card";
// import { ProductDetail } from "../Components/ProductDetail";
// import { ShoppingCartContext } from "../contexts";

// function Dashboard() {
//   const {
//     searchValue,
//     setSearchValue,
//     filteredItems,
//     updateCategoryPath
//   } = useContext(ShoppingCartContext);

//   useEffect(() => {
//     updateCategoryPath(window.location.pathname);
//   }, [updateCategoryPath]);

//   return (
//     <div className="flex flex-col items-center mt-20">
//       <div className="mb-4">
//         <h1 className="font-medium text-xl">Exclusive Products</h1>
//       </div>
//       <input
//         value={searchValue}
//         type="text"
//         placeholder="Search a product"
//         className="rounded-lg border border-black w-80 p-4 mb-4 focus:outline-none"
//         onChange={(event) => setSearchValue(event.target.value)}
//       />
//       <div className="flex-justify-center">
//         <div className="w-[1600px]">
//           <div className="grid gap-4 grid-cols-3">
//             {filteredItems?.map((item) => (
//               <Card key={item.id} data={item} />
//             ))}
//             {filteredItems.length === 0 && <p>No products</p>}
//           </div>  
//         </div>  
//       </div>
//       <ProductDetail />
//       <Outlet /> 
//     </div>
//   );
// }

// export { Dashboard };

// import React, { useContext, useEffect } from "react";
// import { Outlet } from "react-router-dom"; // Import Outlet from react-router-dom
// import { Card } from "../Components/Card/Card";
// import { ProductDetail } from "../Components/ProductDetail";
// import { ShoppingCartContext } from "../contexts";

// function Dashboard() {
//   const {
//     searchValue,
//     setSearchValue,
//     filteredItems,
//     updateCategoryPath
//   } = useContext(ShoppingCartContext);

//   useEffect(() => {
//     updateCategoryPath(window.location.pathname);
//   }, [updateCategoryPath]);

//   // Debugging: Log filteredItems
//   // console.log('Filtered Items:', filteredItems);

//   return (
//     <div className="flex flex-col items-center mt-20">
//       <div className="mb-4">
//         <h1 className="font-medium text-xl">Exclusive Products</h1>
//       </div>
//       <input
//         value={searchValue}
//         type="text"
//         placeholder="Search a product"
//         className="rounded-lg border border-black w-80 p-4 mb-4 focus:outline-none"
//         onChange={(event) => setSearchValue(event.target.value)}
//       />
//       <div className="flex-justify-center">
//         <div className="w-[1024px]">
//           <div className="grid gap-4 grid-cols-4">
//             {filteredItems?.map((item) => (
//               <Card key={item.id} data={item} />
//             ))}
//             {filteredItems.length === 0 && <p>No products</p>}
//           </div>
//         </div>
//       </div>
//       <ProductDetail />
//       <Outlet />
//     </div>
//   );
// }

// export { Dashboard };

import React, { useContext, useEffect } from "react";
import { Outlet } from "react-router-dom";
import { Card } from "../Components/Card/Card";
import { ProductDetail } from "../Components/ProductDetail";
import { ShoppingCartContext } from "../contexts";
import { CheckoutSideMenu } from "../Components/CheckoutSideMenu";

function Dashboard() {
  const {
    searchValue,
    setSearchValue,
    filteredItems,
    updateCategoryPath,
    openCheckoutSideMenu
  } = useContext(ShoppingCartContext);

  useEffect(() => {
    updateCategoryPath(window.location.pathname);
  }, [updateCategoryPath]);

  return (
    <div className="flex flex-col items-center mt-20">
      <div className="mb-4">
        <h1 className="font-medium text-xl">Exclusive Products</h1>
      </div>
      <input
        value={searchValue}
        type="text"
        placeholder="Search a product"
        className="rounded-lg border border-black w-80 p-4 mb-4 focus:outline-none"
        onChange={(event) => setSearchValue(event.target.value)}
      />
      <div className="flex-justify-center">
        <div className="w-[1024px]">
          <div className="grid gap-4 grid-cols-4">
            {filteredItems?.map((item) => (
              <Card key={item.id} data={item} />
            ))}
            {filteredItems.length === 0 && <p>No products</p>}
          </div>
        </div>
      </div>
      <ProductDetail />
      {/* <button onClick={openCheckoutSideMenu} className="mt-4 p-2 bg-blue-500 text-white rounded">Open Checkout</button> */}
      <CheckoutSideMenu />
      <Outlet />
    </div>
  );
}

export { Dashboard };
