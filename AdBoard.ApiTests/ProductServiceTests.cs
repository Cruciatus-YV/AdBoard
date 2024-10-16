using AdBoard.Contracts.Models.Entities.Product.Responses;
using Shouldly;
using System.Net;
using System.Net.Http.Json;

namespace AdBoard.ApiTests
{
    public class ProductServiceTests : IClassFixture<TestWebApplication>
    {
        private readonly TestWebApplication _application;
        private readonly CancellationToken _cancellationToken;


        public ProductServiceTests(TestWebApplication application)
        {
            _application = application;
            _cancellationToken = new CancellationTokenSource().Token;
        }

        [Fact]
        public async Task GetFullInfoAsync_ShouldReturnValidProductResponse()
        {
            //Arrange
            
            //Act
            var httpClient = _application.CreateClient();

            var response = await httpClient.GetAsync($"api/Product/1", _cancellationToken);

            var product = await response.Content.ReadFromJsonAsync<ProductResponse>(_cancellationToken);

            //Assert
            response.ShouldNotBeNull();
            response.StatusCode.ShouldBe(HttpStatusCode.OK);
        }
    }
}