using AutoMapper;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using System.Linq;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<ImportSupplierDto, Supplier>();
            this.CreateMap<ImportPartDto, Part>();
            this.CreateMap<ImportCustomerDto, Customer>();
            this.CreateMap<ImportSaleDto, Sale>();

            this.CreateMap<Part, ExportCarPartDto>();
            this.CreateMap<Car, ExportCarDto>()
                .ForMember(x => x.Parts, y => y.MapFrom(x => x.PartCars.Select(pc => pc.Part)));
            this.CreateMap<Supplier, ExportLocalSuppliersDto>();
            this.CreateMap<Car, ExportCarDistanceDto>();
            this.CreateMap<Car, ExportBMWDto>();
            this.CreateMap<Customer, ExportSalesCustomerDto>()
                .ForMember(x => x.SpentMoney, y => y.MapFrom(x => x.Sales.Select(s => s.Car.PartCars.Select(pc => pc.Part).Sum(pc => pc.Price)).Sum()));
        }
    }
}
