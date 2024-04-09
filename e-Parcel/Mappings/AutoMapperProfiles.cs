using AutoMapper;
using e_Parcel.Models.Domain;
using e_Parcel.Models.DTOs.CartItems;
using e_Parcel.Models.DTOs.Categories;
using e_Parcel.Models.DTOs.Discounts;
using e_Parcel.Models.DTOs.OrderDetails;
using e_Parcel.Models.DTOs.OrderItems;
using e_Parcel.Models.DTOs.PaymentDetails;
using e_Parcel.Models.DTOs.ProductInventories;
using e_Parcel.Models.DTOs.Products;
using e_Parcel.Models.DTOs.ShoppingSessions;

namespace e_Parcel.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CartItem, CartItemDto>().ReverseMap();
            CreateMap<CartItem, CartItemAddDto>().ReverseMap();
            CreateMap<CartItem, CartItemUpdateDto>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryAddDto>().ReverseMap();
            CreateMap<CategoryUpdateDto, Category>().ReverseMap();

            CreateMap<Discount, DiscountDto>().ReverseMap();
            CreateMap<Discount, DiscountAddDto>().ReverseMap();
            CreateMap<Discount, DiscountUpdateDto>().ReverseMap();

            CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailAddDto>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailUpdateDto>().ReverseMap();

            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemAddDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemUpdateDto>().ReverseMap();

            CreateMap<PaymentDetail, PaymentDetailDto>().ReverseMap();
            CreateMap<PaymentDetail, PaymentDetailAddDto>().ReverseMap();
            CreateMap<PaymentDetail, PaymentDetailUpdateDto>().ReverseMap();

            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductAddDto>().ReverseMap();
            CreateMap<Product, ProductUpdateDto>().ReverseMap();

            CreateMap<ProductInventory, ProductInventoryDto>().ReverseMap();
            CreateMap<ProductInventory, ProductInventoryAddDto>().ReverseMap();
            CreateMap<ProductInventory, ProductInventoryUpdateDto>().ReverseMap();

            CreateMap<ShoppingSession, ShoppingSessionDto>().ReverseMap();
            CreateMap<ShoppingSession, ShoppingSessionAddDto>().ReverseMap();
            CreateMap<ShoppingSession, ShoppingSessionUpdateDto>().ReverseMap();
        }
    }
}
