
using FrenetOrder.Models.Dto;
using FrenetOrder.Service;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;
using Assert = Xunit.Assert;

namespace FrenetOrderTest.Service
{
    public class ShippingServiceTests
    {
        private readonly Mock<IConfiguration> _configurationMock;
        private readonly ShippingService _shippingService;

        public ShippingServiceTests()
        {
            _configurationMock = new Mock<IConfiguration>();
            _shippingService = new ShippingService(_configurationMock.Object);
        }


        [Fact]
        public async Task ShippingCalculate_ShouldThrowExceptions_WhenCepOrigemIsInvalid()
        {
            string cepOrigem = "1";
            ShippingCalculateInput shippingCalculateInput = new()
            {
                CepOrigem = cepOrigem,
                CepDestino = "72405486",
                DocumentoDestinatario = "12345648",
                ItemEnvio =
                [
                    new()
                    {
                        Altura = 1M,
                        Cumprimento = 1,
                        Diametro = 1,
                        Largura = 1,
                        Peso = 1,
                        Fragio = true,
                        Quantidade = 1,
                        NomeProduto = "Nome"
                    }
                ],
                ValorPedido = 10M
            };

            await Assert.ThrowsAsync<Exception>(() => _shippingService.ShippingCalculate(shippingCalculateInput));
        }

        [Fact]
        public async Task ShippingCalculate_ShouldThrowExceptions_WhenCepDestinoIsInvalid()
        {
            string cepDestino = "1";
            ShippingCalculateInput shippingCalculateInput = new()
            {
                CepOrigem = "72405486",
                CepDestino = cepDestino,
                DocumentoDestinatario = "12345648",
                ItemEnvio =
                [
                    new()
                    {
                        Altura = 1M,
                        Cumprimento = 1,
                        Diametro = 1,
                        Largura = 1,
                        Peso = 1,
                        Fragio = true,
                        Quantidade = 1,
                        NomeProduto = "Nome"
                    }
                ],
                ValorPedido = 10M
            };

            await Assert.ThrowsAsync<Exception>(() => _shippingService.ShippingCalculate(shippingCalculateInput));
        }

        [Fact]
        public async Task ShippingCalculate_ShouldThrowExceptions_WhenItemEnvioIsEmpty()
        {
            ShippingCalculateInput shippingCalculateInput = new()
            {
                CepOrigem = "72405486",
                CepDestino = "72859543",
                DocumentoDestinatario = "12345648",
                ItemEnvio = [],
                ValorPedido = 10M
            };

            await Assert.ThrowsAsync<Exception>(() => _shippingService.ShippingCalculate(shippingCalculateInput));
        }

        [Fact]
        public async Task ShippingCalculate_ShouldThrowExceptions_WhenItemEnvioQuantityIsInvalid()
        {
            int quantidadeProduto = -1;
            ShippingCalculateInput shippingCalculateInput = new()
            {
                CepOrigem = "72405486",
                CepDestino = "72859543",
                DocumentoDestinatario = "12345648",
                ItemEnvio = 
                [
                    new()
                    {
                        Altura = 1M,
                        Cumprimento = 1,
                        Diametro = 1,
                        Largura = 1,
                        Peso = 1,
                        Fragio = true,
                        Quantidade = quantidadeProduto,
                        NomeProduto = "Nome"
                    }
                ],
                ValorPedido = 10M
            };

            await Assert.ThrowsAsync<Exception>(() => _shippingService.ShippingCalculate(shippingCalculateInput));
        }

        [Fact]
        public async Task ShippingCalculate_ShouldReturnShippingServices_WhenInputIsValid()
        {
            _configurationMock.SetupGet(x => x["Frenet:Username"]).Returns("username");
            _configurationMock.SetupGet(x => x["Frenet:Password"]).Returns("password");
            _configurationMock.SetupGet(x => x["Frenet:Url"]).Returns("http://test.com");
            _configurationMock.SetupGet(x => x["Frenet:ShippingQuotePath"]).Returns("/path");
            _configurationMock.SetupGet(x => x["Frenet:SoapActionQuote"]).Returns("action");
            _configurationMock.SetupGet(x => x["Frenet:Token"]).Returns("token");

            var input = new ShippingCalculateInput
            {
                CepOrigem = "72405486",
                CepDestino = "72405486",
                DocumentoDestinatario = "123456789",
                ValorPedido = 100,
                ItemEnvio = new List<ItemEnvio>
                {
                    new ItemEnvio
                    {
                        Peso = 1,
                        Cumprimento = 10,
                        Altura = 5,
                        Largura = 5,
                        Diametro = 2,
                        Fragio = false,
                        Quantidade = 1,
                        NomeProduto = "Produto Teste"
                    }
                }
            };

            var result = await _shippingService.ShippingCalculate(input);

            Assert.NotNull(result);
            Assert.IsType<List<ShippingSevices>>(result);
        }
    }
}
