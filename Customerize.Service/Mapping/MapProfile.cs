using AutoMapper;
using Customerize.Core.DTOs;
using Customerize.Core.DTOs.Advertisement;
using Customerize.Core.DTOs.Category;
using Customerize.Core.DTOs.Company;
using Customerize.Core.DTOs.Order;
using Customerize.Core.DTOs.OrderLine;
using Customerize.Core.DTOs.Product;
using Customerize.Core.DTOs.ProductType;
using Customerize.Core.DTOs.Region;
using Customerize.Core.DTOs.Shipper;
using Customerize.Core.DTOs.WorkArea;
using Customerize.Core.Entities;

namespace Customerize.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {




            #region Product
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductDtoInsert>().ReverseMap();
            CreateMap<Product, ProductDtoUpdate>().ReverseMap();
            CreateMap<Product, ProductDtoList>().ReverseMap();
            CreateMap<ProductDtoRemoveRange, ProductDtoList>().ReverseMap();
            CreateMap<Product, ProductDtoRemoveRange>().ReverseMap();
            CreateMap<Product, ProductDtoRemoveConfirm>().ReverseMap();
            #endregion

            #region Category
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryDtoInsert>().ReverseMap();
            CreateMap<Category, CategoryDtoUpdate>().ReverseMap();
            CreateMap<Category, CategoryDtoList>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => ((DateTime)src.CreatedDate).ToString("dd-MM-yyyy")))
                .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => src.UpdatedDate == null ? "" : ((DateTime)src.UpdatedDate).ToString("dd-MM-yyyy")))
                .ReverseMap();

            CreateMap<Category, CategoryDtoWithProductList>().ReverseMap();
            CreateMap<CategoryDto, CategoryDtoUpdate>().ReverseMap();
            #endregion

            #region Order
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderDtoInsert, Order>().ReverseMap();
            CreateMap<OrderDtoUpdate, Order>();
            CreateMap<Order, OrderDtoList>().ForMember(dest => dest.ShipperName, opt => opt.MapFrom(src => src.Shipper.Name)).ReverseMap();
            CreateMap<Order, OrderDtoWithOrderLineList>();
            CreateMap<Order, OrderDtoDetails>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.OrderStatus.Title))
                .ForMember(dest => dest.ShipperName, opt => opt.MapFrom(src => src.Shipper.Name))
                .ForMember(dest => dest.Adress, opt => opt.MapFrom(src => src.Company.Adress))
                .ForMember(dest => dest.WorkArea, opt => opt.MapFrom(src => src.Company.WorkArea))
                .ForMember(dest => dest.CompanyPhoneNumber, opt => opt.MapFrom(src => src.Company.CompanyPhoneNumber))
                .ReverseMap();
            #endregion

            #region Company
            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<CompanyDtoInsert, Company>();
            CreateMap<CompanyDtoUpdate, Company>();
            CreateMap<Company, CompanyDtoList>();
            CreateMap<Company, CompanyDtoWithOrderList>();
            CreateMap<Company, CompanyDtoUpdate>();
            #endregion

            #region OrderLine
            CreateMap<OrderLine, OrderLineDto>().ReverseMap();
            CreateMap<OrderLineDtoInsert, OrderLine>();
            CreateMap<OrderLineDtoUpdate, OrderLine>();
            CreateMap<OrderLine, OrderLineDtoList>();
            #endregion

            #region ProductType
            CreateMap<ProductType, ProductTypeDto>().ReverseMap();
            CreateMap<ProductTypeDtoInsert, ProductType>();
            CreateMap<ProductTypeDtoUpdate, ProductType>();
            CreateMap<ProductType, ProductTypeDtoList>();
            CreateMap<ProductType, ProductTypeDtoWithProductList>();
            #endregion

            #region Shipper
            CreateMap<Shipper, ShipperDto>().ReverseMap();
            CreateMap<ShipperDtoInsert, Shipper>();
            CreateMap<ShipperDtoUpdate, Shipper>();
            CreateMap<Shipper, ShipperDtoList>();
            CreateMap<Shipper, ShipperDtoWithOrder>();
            #endregion

            #region Region
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<RegionDtoInsert, Region>();
            CreateMap<RegionDtoUpdate, Region>();
            CreateMap<Region, RegionDtoList>();
            #endregion

            #region WorkArea
            CreateMap<WorkArea, WorkAreaDto>().ReverseMap();
            CreateMap<WorkAreaDtoInsert, WorkArea>();
            CreateMap<WorkAreaDtoUpdate, WorkArea>();
            CreateMap<WorkArea, WorkAreaDtoList>();
            #endregion

            #region Advertisement

            CreateMap<Advertisement, AdvertisementDtoList>().ReverseMap();
            CreateMap<Advertisement, AdvertisementDtoInsert>().ReverseMap();
            #endregion



            var configuration = new MapperConfiguration(cfg => cfg.CreateMap(typeof(Source<>), typeof(Destination<>)));

        }
        public class Source<T>
        {
            public T Value { get; set; }
        }

        public class Destination<T>
        {
            public T Value { get; set; }
        }

    }
}
