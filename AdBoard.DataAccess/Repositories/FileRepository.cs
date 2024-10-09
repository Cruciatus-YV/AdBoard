using AdBoard.AppServices.Contexts.File.Repositories;
using AdBoard.Infrastructure;
using AdBoard.Infrastructure.Repositories;

namespace AdBoard.DataAccess.Repositories;

public class FileRepository(AdBoardDbContext dbContext) : GenericRepository<FileEntity, long>(dbContext), IFileRepository
{

}
