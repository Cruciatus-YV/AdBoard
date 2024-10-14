using AdBoard.AppServices.Contexts.File.Services;
using AdBoard.AppServices.Contexts.Store.Repositories;
using AdBoard.AppServices.Exceptions;
using AdBoard.Contracts.Enums;
using AdBoard.Contracts.Models.Entities.Store.Requests;
using AdBoard.Contracts.Models.Entities.Store.Responses;
using AdBoard.Contracts.Models.Entities.User;
using AdBoard.Contracts.Models.Entities.User.Responses;
using AdBoard.Domain.Entities;

namespace AdBoard.AppServices.Contexts.Store.Services;

public class StoreService : IStoreService
{
    private readonly IStoreRepository _storeRepository;
    private readonly IFileService _fileService;


    public StoreService(IStoreRepository storeRepository, IFileService fileService)
    {
        _storeRepository = storeRepository;
        _fileService = fileService;
    }

    public async Task<long> CreateAsync(StoreRequestCreate request, UserContextLight userContextLightDto, CancellationToken cancellationToken)
    {
        long? avatar = null;

        if (request.Avatar != null)
        {
            avatar = await _fileService.UploadAsync(request.Avatar, cancellationToken);
        }

        var entity = new StoreEntity 
        { 
            Name = request.Name,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            Description = request.Description,
            IsDefault = false,
            SellerId = userContextLightDto.Id,
            Status = StoreStatus.Available,
            AvatarId = avatar,
        };

        return await _storeRepository.InsertAsync(entity, cancellationToken);
    }

    public async Task<StoreResponse?> GetAsync(long id, CancellationToken cancellationToken)
    {
        var store = await _storeRepository.GetByIdAsync(id, cancellationToken);

        if (store == null) 
        {
            throw new NotFoundException("Магазин не найден");    
        }

        return new StoreResponse
        {
            Description = store.Description,
            Id = store.Id,
            IsDefault = store.IsDefault,
            Name = store.Name,
            Status = store.Status,
            Seller = new UserLigthResponse(store.SellerId, store.Seller.FirstName, store.Seller.LastName, store.Seller.Email)
        };
    }

    public async Task UpdateAsync(StoreRequestUpdate request, UserContextLight userContextLightDto, CancellationToken cancellationToken)
    {
        var store = await _storeRepository.GetByPredicate(x => x.Id == request.Id && x.SellerId == userContextLightDto.Id, cancellationToken);

        if (store == null)
        {
            throw new NotFoundException("Магазин не найден");
        }

        long? avatar = null;

        if (request.Avatar != null)
        {
            if(store.AvatarId.HasValue)
            {
                await _fileService.DeleteAsync(store.AvatarId.Value, cancellationToken);
            }

            avatar = await _fileService.UploadAsync(request.Avatar, cancellationToken);
        }

        store.Name = request.Name;
        store.Description = request.Description;
        store.Status = request.Status;
        store.UpdatedAt = DateTime.UtcNow;
        store.AvatarId = avatar;

        await _storeRepository.UpdateAsync(store, cancellationToken);
    }
}