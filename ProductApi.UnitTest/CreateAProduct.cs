using Moq;
using ProductApi.Application.Services;
using ProductApi.Domain.Entities;
using ProductApi.Domain.Repository;

namespace ProductApi.UnitTest
{
    public class CreateAProduct
    {
        [Fact]
        public async Task DadoUmProdutoRetornaCriado()
        {   //Arange
            var product = new Product { Id = "1", Nome = "Produto Quente 1", Preco = 10.0, Quantidade = 5, Estoque = "24E10" };

            var repository = new Mock<IProductRepository>();
            repository.Setup(x => x.CreateAsync(product)).ReturnsAsync(product);

            var service = new ProductService(repository.Object);
            //Act 
            var result = await service.CreateAsync(product);

            //Assert
            Assert.NotNull(result);

            Assert.Equal(product.Nome, result.Nome);

            repository.Verify(x => x.CreateAsync(product), Times.Once);
        }

        [Fact]
        public async Task DadoUmProdutoInvalidoRetornaVazio()
        {
            // Arrange
            Product? product = new Product { Id = "1", Nome = "Produto Quente 1", Preco = -1, Quantidade = 5, Estoque = "24E10" };

            var repository = new Mock<IProductRepository>();

            var service = new ProductService(repository.Object);

            // Act 
            var result = await service.CreateAsync(product);

            // Assert
            Assert.Null(result);

            repository.Verify(x => x.CreateAsync(product), Times.Never);
        }
    }
}