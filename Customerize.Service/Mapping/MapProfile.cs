using AutoMapper;
using Customerize.Core.DTOs;
using Customerize.Core.DTOs.Category;
using Customerize.Core.DTOs.Company;
using Customerize.Core.DTOs.Order;
using Customerize.Core.DTOs.OrderLine;
using Customerize.Core.DTOs.Product;
using Customerize.Core.DTOs.ProductType;
using Customerize.Core.DTOs.Region;
using Customerize.Core.DTOs.Shipper;
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
            #endregion

            #region Category
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryDtoInsert>().ReverseMap();
            CreateMap<Category, CategoryDtoUpdate>().ReverseMap();
            CreateMap<Category, CategoryDtoList>().ReverseMap();
            CreateMap<Category, CategoryDtoWithProductList>().ReverseMap();
            CreateMap<CategoryDto, CategoryDtoUpdate>().ReverseMap();
            #endregion

            #region Order
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderDtoInsert, Order>();
            CreateMap<OrderDtoUpdate, Order>();
            CreateMap<Order, OrderDtoList>();
            CreateMap<Order, OrderDtoWithOrderLineList>();
            #endregion

            #region Company
            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<CompanyDtoInsert, Company>();
            CreateMap<CompanyDtoUpdate, Company>();
            CreateMap<Company, CompanyDtoList>();
            CreateMap<Company, CompanyDtoWithOrderList>();
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


        }
    }
}
