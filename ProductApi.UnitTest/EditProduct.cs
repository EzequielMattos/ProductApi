using Moq;
using ProductApi.Application.Services;
using ProductApi.Domain.Entities;
using ProductApi.Domain.Repository;

namespace ProductApi.UnitTest
{
    public class EditProduct
    {
        [Fact]
        public async Task DadoUmProdutoRetornaAlterado()
        {   //Arange
            var product = new Product { Id = "1", Nome = "Produto Quente 1", Preco = 10.0, Quantidade = 5, Estoque = "24E10" };

            var repository = new Mock<IProductRepository>();
            repository.Setup(x => x.GetByIdAsync(product.Id)).ReturnsAsync(product);
            repository.Setup(x => x.UpdateAsync(product)).ReturnsAsync(product);

            var service = new ProductService(repository.Object);

            //Act 
            product.Nome = "Produto alterado";
            var result = await service.UpdateAsync(product, product.Id);

            //Assert
            Assert.NotNull(result);

            Assert.Equal("Produto alterado", result.Nome);

            repository.Verify(x => x.GetByIdAsync(product.Id), Times.Once);
            repository.Verify(x => x.UpdateAsync(product), Times.Once);
        }

        [Fact]
        public async Task DadoUmProdutoNaoExistenteRetornaNotFound()
        {
            // Arrange
            Product? product = new Product { Id = "1", Nome = "Produto Quente 1", Preco = 10.0, Quantidade = 5, Estoque = "24E10" };

            var repository = new Mock<IProductRepository>();

            var service = new ProductService(repository.Object);

            // Act 
            var result = await service.UpdateAsync(product, product.Id);

            // Assert
            Assert.Null(result);

            repository.Verify(x => x.UpdateAsync(product), Times.Never);
        }
    }
}