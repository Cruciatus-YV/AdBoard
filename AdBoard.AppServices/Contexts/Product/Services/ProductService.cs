using AdBoard.AppServices.Contexts.File.Services;
using AdBoard.AppServices.Contexts.Product.Repositories;
using AdBoard.AppServices.Contexts.Product.SpecificationBuilder;
using AdBoard.AppServices.Contexts.Store.Repositories;
using AdBoard.AppServices.Exceptions;
using AdBoard.Contracts.Enums;
using AdBoard.Contracts.Models.Entities.Product;
using AdBoard.Contracts.Models.Entities.Product.Requests;
using AdBoard.Contracts.Models.Entities.Product.Responses;
using AdBoard.Contracts.Models.Entities.User;
using AdBoard.Domain.Entities;

namespace AdBoard.AppServices.Contexts.Product.Services;

/// <summary>
/// Сервис для работы с товарами.
/// </summary>
public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IProductSpecificationBuilder _productSpecificationBuilder;
    private readonly IStoreRepository _storeRepository;
    private readonly IFileService _fileService;

    public ProductService(IProductRepository productRepository,
                          IProductSpecificationBuilder productSpecificationBuilder,
                          IStoreRepository storeRepository,
                          IFileService fileService)
    {
        _productRepository = productRepository;
        _productSpecificationBuilder = productSpecificationBuilder;
        _storeRepository = storeRepository;
        _fileService = fileService;
    }

    public async Task<long> CreateAsync(ProductRequestCreate request, UserContextLight userContext, CancellationToken cancellationToken)
    {
        if (request.MeasurementUnit == MeasurementUnit.None)
        {
            throw new NoneMeasurementUnitException("Не указана единица измерения количества товара");
        }

        var store = await _storeRepository.GetByPredicate(x => x.Id == request.StoreId, cancellationToken);

        if (store == null)
        {
            throw new NotFoundException("Магазин не найден.");
        }

        else if (userContext.IsUser && store.SellerId != userContext.Id)
        {

            throw new AccessDeniedException("Доступ запрещён");

        }

        var entity = new ProductEntity
        {
            Name = request.Name,
            CategoryId = request.CategoryId,
            Count = request.Count,
            Price = request.Price,
            MeasurementUnit = request.MeasurementUnit,
            Description = request.Description,
            StoreId = request.StoreId,
            Status = ProductStatus.Available,
        };

        entity.Id = await _productRepository.InsertAsync(entity, cancellationToken);

        if (request.Images?.Any() == true)
        {
            entity.Images = await FileService.CalculateFiles(request.Images, cancellationToken);
        }

        return entity.Id;

    }

    public async Task<bool> DeleteAsync(long id, UserContextLight userContext, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdWithStore(id, cancellationToken);

        if (product == null)
        {
            throw new NotFoundException("Cущность не найдена.");
        }
        else if (!userContext.IsSuperAdmin && !userContext.IsSuperManager && !(userContext.Id == product.Store.SellerId))
        {
            throw new Exception("Нет доступа");
        }

        return await _productRepository.DeleteProductAsync(id, cancellationToken);
    }

    public async Task<List<ProductPageItemDto>> GetByFilterAsync(ProductRequestSearch request, CancellationToken cancellationToken)
    {
        var specification = _productSpecificationBuilder.Build(request);

        return await _productRepository.GetProductsBySpecificationWithSortingAndPaginationAsync(specification,
                                                                                                request.SortBy,
                                                                                                request.SearchOnlyByName,
                                                                                                request.PageNumber,
                                                                                                request.PageSize,
                                                                                                cancellationToken);
    }

    public async Task<ProductResponse?> GetFullInfoAsync(long id, CancellationToken cancellationToken)
    {
        var result = await _productRepository.GetFullInfoAsync(id, cancellationToken);

        return result;
    }

    public async Task<bool> UpdateAsync(ProductRequestUpdate request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdWithImages(request.Id, cancellationToken);

        if (product == null)
        {
            throw new NotFoundException("Cущность не найдена.");
        }

        product.Name = request.Name;
        product.CategoryId = request.CategoryId;
        product.Description = request.Description;
        product.Price = request.Price;
        product.Count = request.Count;
        product.MeasurementUnit = request.MeasurementUnit;
        product.Status = request.Status;
        product.UpdatedAt = DateTime.UtcNow;

        if (request.DeletedImages?.Any() == true)
        {
            product.Images = product.Images.Where(x => !request.DeletedImages.Contains(x.Id)).ToList();
            await _fileService.DeleteListAsync(request.DeletedImages, cancellationToken);
        }

        if (request.Images?.Any() == true)
        {
            product.Images = await FileService.CalculateFiles(request.Images, cancellationToken);
        }

        product.UpdatedAt = DateTime.UtcNow;

        return await _productRepository.UpdateAsync(product, cancellationToken);
    }

    public async Task<(bool, IReadOnlyCollection<long>?)> UpdateCountAsync(IReadOnlyCollection<ProductRequestBuyable> request, CancellationToken cancellationToken)
    {
        var result = await _productRepository.UpdateProductCountAsync(request, cancellationToken);

        return result;
    }
}