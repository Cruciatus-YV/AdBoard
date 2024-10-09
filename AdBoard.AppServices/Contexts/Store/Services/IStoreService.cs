using AdBoard.Contracts.Models.Entities.Store.Requests;
using AdBoard.Contracts.Models.Entities.Store.Responses;
using AdBoard.Contracts.Models.Entities.User;

namespace AdBoard.AppServices.Contexts.Store.Services;

public interface IStoreService
{
    Task<long> CreateAsync(StoreRequestCreate request, UserContextLightDto userContextLightDto, CancellationToken cancellationToken);
    Task<StoreResponse?> GetAsync(long id, CancellationToken cancellationToken);
    Task UpdateAsync(StoreRequestUpdate request, UserContextLightDto userContextLightDto, CancellationToken cancellationToken);
}
