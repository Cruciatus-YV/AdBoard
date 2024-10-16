using AdBoard.AppServices.Cache;
using AdBoard.AppServices.Contexts.Category.Repositories;
using AdBoard.AppServices.Contexts.Category.Services;
using AdBoard.Contracts.Models.Entities.Category.Requests;
using AdBoard.Domain.Entities;
using Moq;

namespace AdBoard.Tests
{
    public class CategoryServiceTests
    {
        [Fact]
        public async Task CreateUnapprovedAsync_ShouldCallInsertAsyncWithCorrectEntity()
        {
            // Arrange: настраиваем зависимости и данные
            var mockRepository = new Mock<ICategoryRepository>();
            var mockCacheService = new Mock<ICacheService>();
            var categoryService = new CategoryService(mockRepository.Object, mockCacheService.Object);

            var request = new CategoryRequestCreate
            {
                Name = "TestCategory",
                ParentId = 1
            };

            mockRepository.Setup(repo => repo.InsertAsync(It.IsAny<CategoryEntity>(), It.IsAny<CancellationToken>()))
                          .ReturnsAsync(1);

            // Act: вызываем тестируемый метод
            var result = await categoryService.CreateUnapprovedAsync(request, CancellationToken.None);

            // Assert: проверяем результат
            mockRepository.Verify(repo => repo.InsertAsync(It.Is<CategoryEntity>(c => c.Name == request.Name && c.ParentId == request.ParentId),
                                                           It.IsAny<CancellationToken>()),
                                                           Times.Once);
            Assert.Equal(1, result);
        }
    }
}
