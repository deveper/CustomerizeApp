using AutoMapper;
using Common.Dtos;
using Common.StaticClasses;
using Customerize.Common.Dtos;
using Customerize.Core.DTOs.Category;
using Customerize.Core.DTOs.Product;
using Customerize.Core.Entities;
using Customerize.Core.Repositories;
using Customerize.Core.Services;
using Customerize.Core.UnitOfWorks;
using Customerize.Repository.Repostories;
using System.Reflection.Metadata.Ecma335;

namespace Customerize.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepositroy _productRepositroy;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<ProductDocument> _productDocumentRepository;


        public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IProductRepositroy productRepository, IMapper mapper, IGenericRepository<ProductDocument> productDocumentRepository) : base(repository, unitOfWork, mapper)
        {
            _productRepositroy = productRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _productDocumentRepository = productDocumentRepository;
        }

        public async Task<ResultDto> Create(ProductDtoInsert input)
        {
            if (input != null)
            {
                var model = new Product()
                {
                    Name = input.Name,
                    Stock = input.Stock,
                    Price = input.Price,
                    CategoryId = input.CategoryId,
                    ProductTypeId = input.ProductTypeId,
                };
                await _productRepositroy.AddAsync(model);
                await _unitOfWork.CommitAsync();
                if (input.formFiles != null)
                {
                    string uploadsFolder = Path.Combine("wwwroot\\Product");

                    foreach (var item in input.formFiles)
                    {
                        var path = uploadsFolder + "/" + item.FileName;
                        using (var stream = new FileStream(path, FileMode.Create))
                        {

                            await item.CopyToAsync(stream);

                        }
                    };
                    var productDocuments = new List<ProductDocument>();
                    productDocuments.AddRange(input.formFiles.Select(x => new ProductDocument
                    {
                        ProductId = model.Id,
                        Path = uploadsFolder + x.FileName,
                        Title = x.FileName
                    }));
                    await _productDocumentRepository.AddRangeAsync(productDocuments);
                    await _unitOfWork.CommitAsync();
                }
                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = ResultMessages.GeneralAddedMessage,
                };

            }
            else if (input == null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = ResultMessages.ProductInformationMissing,
                };
            }

            return new ResultDto()
            {
                IsSuccess = false,
                Message = ResultMessages.GeneralErrorMessage,
                Total = 0
            };
        }

        public ResultDto<List<ProductDtoList>> GetAllProductForDataTable(DataTableModel input)
        {
            var products = _productRepositroy.GetAll();
            if (products != null)
            {
                if (!(string.IsNullOrEmpty(input.SortColumn) && string.IsNullOrEmpty(input.SortColumnDirection)))
                {

                    products = input.SortColumnDirection == "asc" ? products.OrderBy(x => input.SortColumn) : products.OrderByDescending(x => input.SortColumn);
                    switch (input.SortColumn)
                    {
                        case "Id":
                            products = input.SortColumnDirection == "asc" ? products.OrderBy(x => x.Id) : products.OrderByDescending(x => x.Id);
                            break;
                        case "CreatedDate":
                            products = input.SortColumnDirection == "asc" ? products.OrderBy(x => x.CreatedDate) : products.OrderByDescending(x => x.CreatedDate);
                            break;
                        case "Name":
                            products = input.SortColumnDirection == "asc" ? products.OrderBy(x => x.Name) : products.OrderByDescending(x => x.Name);
                            break;

                    }
                }

                if (!string.IsNullOrEmpty(input.SsearchValue))
                {
                    products = products.Where(x => x.Name.Contains(input.SsearchValue));
                }

                var map = _mapper.Map<List<ProductDtoList>>(products);
                var data = map.Skip(input.Skip).Take(input.PageSize);
                var recordsTotal = map.Count();

                return new ResultDto<List<ProductDtoList>>()
                {
                    Data = data.ToList(),
                    IsSuccess = true,
                    Message = ResultMessages.GeneralSuccess,
                    Total = recordsTotal,
                    Req = input.Draw

                };
            }
            return new ResultDto<List<ProductDtoList>>()
            {
                IsSuccess = false,
                Message = ResultMessages.GeneralErrorMessage,
                Total = 0,
            };
        }

        public async Task<ResultDto<IEnumerable<ProductDtoList>>> GetProductAllDetail()
        {
            var products = await _productRepositroy.GetFullProduct();
            if (products != null)
            {
                var map = _mapper.Map<IEnumerable<ProductDtoList>>(products);
                return new ResultDto<IEnumerable<ProductDtoList>>()
                {
                    Data = map,
                    IsSuccess = true,
                    Message = ResultMessages.ProductsAllDetail
                };
            }
            return new ResultDto<IEnumerable<ProductDtoList>>()
            {
                IsSuccess = false,
                Message = ResultMessages.NotFoundProducts
            };
        }

        public async Task<ResultDto<IList<ProductDtoRemoveRange>>> RemoveRangeProduct(IList<ProductDtoRemoveRange> input)
        {
            var deleteItem = input.Select(x => x.DeleteProducts).Where(x => x.Selected == true).ToList();
            if (deleteItem.Any())
            {
                List<Product> deletedProducts = new List<Product>();
                foreach (var item in input)
                {
                    if (item.DeleteProducts.Selected)
                    {
                        var selectedProduct = await _productRepositroy.GetByIdAsync(item.Id);
                        deletedProducts.Add(selectedProduct);
                    }
                }
                if (deletedProducts != null)
                {
                    _productRepositroy.RemoveRange(deletedProducts);
                    var success = await _unitOfWork.CommitAsync();
                    if (success)
                    {
                        return new ResultDto<IList<ProductDtoRemoveRange>>()
                        {
                            IsSuccess = true,
                            Message = ResultMessages.DeletedProduct,
                            Total = deleteItem.Count,
                        };
                    }
                }
            }
            return new ResultDto<IList<ProductDtoRemoveRange>>()
            {
                Data = input,
                IsSuccess = false,
                Message = ResultMessages.NotFoundDeletedProducts,

            };

        }
    }
}
