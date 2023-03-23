namespace CarDealer;

using AutoMapper;
using CarDealer.DTOs.Export;
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

        this.CreateMap<Part, ExportCarPartDto>();

        // Car 
        this.CreateMap<ImportCarDto, Car>()
            .ForSourceMember(s => s.Parts,
                opt => opt.DoNotValidate());

        this.CreateMap<Car, ExportCarWithRangeDto>();

        this.CreateMap<Car, ExportMakeBmwCarDto>();

        this.CreateMap<Car, ExportCarWithPartsDto>()
            .ForMember(p => p.Parts,
                opt => opt.MapFrom(s =>
                    s.PartsCars
                        .Select(pc => pc.Part)
                        .OrderByDescending(pr => pr.Price)
                        .ToArray()));

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
