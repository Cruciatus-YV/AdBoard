using AdBoard.AppServices.Contexts.Store.Repositories;
using AdBoard.AppServices.Exceptions;
using AdBoard.Contracts.Enums;
using AdBoard.Contracts.Models.Entities.Store.Requests;
using AdBoard.Contracts.Models.Entities.Store.Responses;
using AdBoard.Contracts.Models.Entities.User;
using AdBoard.Domain.Entities;

namespace AdBoard.AppServices.Contexts.Store.Services;

public class StoreService : IStoreService
{
    private readonly IStoreRepository _storeRepository;

    public StoreService(IStoreRepository storeRepository)
    {
        _storeRepository = storeRepository;
    }

    public async Task<long> CreateAsync(StoreRequestCreate request, UserContextLightDto userContextLightDto, CancellationToken cancellationToken)
    {
        var entity = new StoreEntity 
        { 
            Name = request.Name,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            Description = request.Description,
            IsDefault = false,
            SellerId = userContextLightDto.Id,
            Status = StoreStatus.Available,
        };

        return await _storeRepository.InsertAsync(entity, cancellationToken);
    }

    public async Task<StoreResponse?> GetAsync(long id, CancellationToken cancellationToken)
    {
       return await _storeRepository.GetStoreInfo(id, cancellationToken);
    }

    public async Task UpdateAsync(StoreRequestUpdate request, UserContextLightDto userContextLightDto, CancellationToken cancellationToken)
    {
        var store = await _storeRepository.GetByPredicate(x => x.Id == request.Id && x.SellerId == userContextLightDto.Id, cancellationToken);

        if (store == null)
        {
            throw new NotFoundException("Магазин не найден");
        }

        store.Name = request.Name;
        store.Description = request.Description;
        store.Status = request.Status;
        store.UpdatedAt = DateTime.UtcNow;

        await _storeRepository.UpdateAsync(store, cancellationToken);
    }
}