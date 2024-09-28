using AdBoard.AppServices.Contexts.Store.Repositories;

namespace AdBoard.AppServices.Contexts.Store.Services;

public class StoreService : IStoreService
{
    private readonly IStoreRepository _storeRepository;

    public StoreService(IStoreRepository storeRepository)
    {
        _storeRepository = storeRepository;
    }
}