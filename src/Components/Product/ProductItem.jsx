// import { PropTypes } from "prop-types";
// import { Link } from "react-router-dom";
// import styled from "styled-components";
// import { commonCardStyles } from "../../styles/card";
// import { breakpoints, defaultTheme } from "../../styles/themes/default";

// const ProductCardWrapper = styled(Link)`
//   ${commonCardStyles}
//   @media(max-width: ${breakpoints.sm}) {
//     padding-left: 0;
//     padding-right: 0;
//   }

//   .product-img {
//     height: 393px;
//     position: relative;

//     @media (max-width: ${breakpoints.sm}) {
//       height: 320px;
//     }
//   }

//   .product-wishlist-icon {
//     position: absolute;
//     top: 16px;
//     right: 16px;
//     width: 32px;
//     height: 32px;
//     border-radius: 100%;

//     &:hover {
//       background-color: ${defaultTheme.color_yellow};
//       color: ${defaultTheme.color_white};
//     }
//   }
// `;

// const ProductItem = ({ product }) => {
//   return (
//     <ProductCardWrapper key={product.id} to="/product/details">
//       <div className="product-img">
//         <img className="object-fit-cover" src={product.imgSource} />
//         <button
//           type="button"
//           className="product-wishlist-icon flex items-center justify-center bg-white"
//         >
//           <i className="bi bi-heart"></i>
//         </button>
//       </div>
//       <div className="product-info">
//         <p className="font-bold">{product.title}</p>
//         <div className="flex items-center justify-between text-sm font-medium">
//           <span className="text-gray">{product.brand}</span>
//           <span className="text-outerspace font-bold">${product.price}</span>
//         </div>
//       </div>
//     </ProductCardWrapper>
//   );
// };

// export default ProductItem;

// ProductItem.propTypes = {
//   product: PropTypes.object,
// };

import { PropTypes } from "prop-types";
import { Link } from "react-router-dom";
import styled from "styled-components";
import { commonCardStyles } from "../../styles/card";
import { breakpoints, defaultTheme } from "../../styles/themes/default";

const ProductCardWrapper = styled(Link)`
  ${commonCardStyles}
  @media(max-width: ${breakpoints.sm}) {
    padding-left: 0;
    padding-right: 0;
  }

  .product-img {
    height: 393px;
    position: relative;

    @media (max-width: ${breakpoints.sm}) {
      height: 320px;
    }
  }

  .product-wishlist-icon {
    position: absolute;
    top: 16px;
    right: 16px;
    width: 32px;
    height: 32px;
    border-radius: 100%;

    &:hover {
      background-color: ${defaultTheme.color_yellow};
      color: ${defaultTheme.color_white};
    }
  }
`;

const ProductItem = ({ product = null }) => {
  if (!product) {
    return null; // or a fallback UI
  }

  return (
    <ProductCardWrapper key={product.id} to={`/product/details/${product.id}`}>
      <div className="product-img">
        <img className="object-fit-cover" src={product.imgSource} alt={product.title} />
        <button
          type="button"
          className="product-wishlist-icon flex items-center justify-center bg-white"
        >
          <i className="bi bi-heart"></i>
        </button>
      </div>
      <div className="product-info">
        <p className="font-bold">{product.title}</p>
        <div className="flex items-center justify-between text-sm font-medium">
          <span className="text-gray">{product.brand}</span>
          <span className="text-outerspace font-bold">${product.price}</span>
        </div>
      </div>
    </ProductCardWrapper>
  );
};

ProductItem.propTypes = {
  product: PropTypes.shape({
    id: PropTypes.oneOfType([PropTypes.string, PropTypes.number]).isRequired,
    imgSource: PropTypes.string.isRequired,
    title: PropTypes.string.isRequired,
    brand: PropTypes.string.isRequired,
    price: PropTypes.oneOfType([PropTypes.string, PropTypes.number]).isRequired,
  }),
};

export default ProductItem;
