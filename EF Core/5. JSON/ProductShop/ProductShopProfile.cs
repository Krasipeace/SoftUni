namespace ProductShop;

using AutoMapper;

using ProductShop.Models;
using DTOs.Import;
using ProductShop.DTOs.Export;

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

        // Import Categories and Products
        this.CreateMap<ImportCategoriesAndProducts, CategoryProduct>();

        // Export Products in Range
        this.CreateMap<Product, ExportProducts>()
            .ForMember(ep => ep.SellerFullName, opt => opt
                .MapFrom(s => $"{s.Seller.FirstName} {s.Seller.LastName}"));
    }
}
