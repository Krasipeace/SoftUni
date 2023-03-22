namespace CarDealer;

using AutoMapper;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using System.Globalization;

public class CarDealerProfile : Profile
{
    public CarDealerProfile()
    {
        // Supplier
        this.CreateMap<ImportSupplierDTO, Supplier>();

        // Part 
        this.CreateMap<ImportPartDto, Part>()
            .ForMember(d => d.SupplierId,
                opt => opt.MapFrom(s => s.SupplierId!.Value));

        // Car 
        this.CreateMap<ImportCarDto, Car>()
            .ForSourceMember(s => s.Parts,
                opt => opt.DoNotValidate());

        // Customer 
        this.CreateMap<ImportCustomerDto, Customer>()
            .ForMember(d => d.BirthDate,
                opt => opt.MapFrom(s => DateTime.Parse(s.BirthDate, CultureInfo.InvariantCulture)));

        // Sale
        this.CreateMap<ImportSaleDto, Sale>()
            .ForMember(s => s.CarId, 
                opt => opt.MapFrom(s => s.CarId.Value));
    }
}
