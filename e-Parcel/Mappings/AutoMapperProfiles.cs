using AutoMapper;
using e_Parcel.Models.Domain;
using e_Parcel.Models.DTOs;

namespace e_Parcel.Mappings
{
	public class AutoMapperProfiles : Profile
	{
		public AutoMapperProfiles()
		{
			CreateMap<Category, CategoryDto>().ReverseMap();
			CreateMap<Category, CategoryAddDto>().ReverseMap();
			CreateMap<CategoryUpdateDto, Category>().ReverseMap();
			CreateMap<ProductInventory, ProductInventoryDto>().ReverseMap();
			CreateMap<ProductInventory, ProductInventoryAddDto>().ReverseMap();
			CreateMap<ProductInventory, ProductInventoryUpdateDto>().ReverseMap();

		}
	}
}
