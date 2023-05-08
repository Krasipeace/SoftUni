namespace Invoices
{
    using System.Globalization;

    using AutoMapper;

    using Data.Models;
    using DataProcessor.ExportDto;

    public class InvoicesProfile : Profile
    {
        public InvoicesProfile()
        {
            CreateMap<Client, ExportClientsDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.NumberVat, opt => opt.MapFrom(s => s.NumberVat))
                .ForMember(d => d.Invoices, opt => opt.MapFrom(s => s.Invoices.ToArray().OrderBy(i => i.IssueDate).ThenByDescending(i => i.DueDate)));

            CreateMap<Invoice, ExportInvoicesDto>()
                 .ForMember(d => d.Number, opt => opt.MapFrom(s => s.Number))
                 .ForMember(d => d.Amount, opt => opt.MapFrom(s => s.Amount))
                 .ForMember(d => d.DueDate, opt => opt.MapFrom(s => s.DueDate.ToString("d", CultureInfo.InvariantCulture)))
                 .ForMember(d => d.Currency, opt => opt.MapFrom(s => s.CurrencyType.ToString()));
        }
    }
}
