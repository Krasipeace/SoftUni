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
    }
}
