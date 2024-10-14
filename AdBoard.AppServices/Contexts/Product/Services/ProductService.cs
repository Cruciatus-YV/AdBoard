﻿using Abp.Domain.Entities;
using AdBoard.AppServices.Contexts.File.Services;
using AdBoard.AppServices.Contexts.Product.Repositories;
using AdBoard.AppServices.Contexts.Product.SpecificationBuilder;
using AdBoard.AppServices.Contexts.ProductImage.Repositories;
using AdBoard.AppServices.Contexts.Store.Repositories;
using AdBoard.AppServices.Exceptions;
using AdBoard.Contracts.Enums;
using AdBoard.Contracts.Models.Entities.Product;
using AdBoard.Contracts.Models.Entities.Product.Requests;
using AdBoard.Contracts.Models.Entities.Product.Responses;
using AdBoard.Contracts.Models.Entities.User;
using AdBoard.Domain.Entities;

namespace AdBoard.AppServices.Contexts.Product.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IProductSpecificationBuilder _productSpecificationBuilder;
    private readonly IStoreRepository _storeRepository;
    private readonly IProductImageRepository _productImageRepository;
    private readonly IFileService _fileService;



    public ProductService(IProductRepository productRepository,
                          IProductSpecificationBuilder productSpecificationBuilder,
                          IStoreRepository storeRepository,
                          IProductImageRepository productImageRepository,
                          IFileService fileService)
    {
        _productRepository = productRepository;
        _productSpecificationBuilder = productSpecificationBuilder;
        _storeRepository = storeRepository;
        _productImageRepository = productImageRepository;
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
        };

        entity.Id = await _productRepository.InsertAsync(entity, cancellationToken);

        if (request.Images?.Any() == true)
        {
            var images = await _fileService.UploadListAsync(request.Images, cancellationToken);

            var productImageEntities = images.Select(x => new ProductImageEntity
            {
                FileId = x.Id,
                ProductId = entity.Id,
            }).ToList();

            await _productImageRepository.InsertListAsync(productImageEntities, cancellationToken);
        }

        return entity.Id;

    }

    public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken)
    {
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
        var target = await _productRepository.GetByIdWithImages(request.Id, cancellationToken);

        if (target == null)
        {
            throw new NotFoundException("Cущность не найдена.");
        }

        target.Name = request.Name;
        target.CategoryId = request.CategoryId;
        target.Description = request.Description;
        target.Price = request.Price;
        target.Count = request.Count;
        target.MeasurementUnit = request.MeasurementUnit;
        target.Status = request.Status;
        target.UpdatedAt = DateTime.UtcNow;

        if (request.Images?.Any() == true)
        {
            if(target.Images?.Any() == true)
            {
                await _fileService.DeleteListAsync(target.Images.Select(x => x.FileId).ToList(), cancellationToken);
            }

            var images = await _fileService.UploadListAsync(request.Images, cancellationToken);

            var productImageEntities = images.Select(x => new ProductImageEntity
            {
                FileId = x.Id,
                ProductId = target.Id,
            }).ToList();

            await _productImageRepository.InsertListAsync(productImageEntities, cancellationToken);
        }

        return await _productRepository.UpdateAsync(target, cancellationToken);
    }

    public async Task<(bool, IReadOnlyCollection<long>?)> UpdateCountAsync(IReadOnlyCollection<ProductRequestBuyable> request, CancellationToken cancellationToken)
    {
        var target = await _productRepository.UpdateProductCountAsync(request, cancellationToken);

        return target;
    }
}