using AdBoard.AppServices.Store.Repositories;

namespace AdBoard.AppServices.Store.Services;

public class StoreService : IStoreService
{
    private readonly IStoreRepository _storeRepository;

    public StoreService(IStoreRepository storeRepository)
    {
        _storeRepository = storeRepository;
    }
}