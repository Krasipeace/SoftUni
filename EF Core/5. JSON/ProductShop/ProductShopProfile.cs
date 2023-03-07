namespace ProductShop;

using AutoMapper;

using ProductShop.Models;
using DTOs.Import;

public class ProductShopProfile : Profile
{
    public ProductShopProfile() 
    {
        // Import Users
        this.CreateMap<ImportUsers, User>();

        // Import Products
        this.CreateMap<ImportProducts, Product>();

        // Import Categories
        this.CreateMap<ImportCategories, Category>();
    }
}
