using FrenetOrder.Models.Dto;
using FrenetOrder.Service;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;
using Assert = Xunit.Assert;

namespace FrenetOrderTest.Service
{
    public class ShippingServiceTests
    {
        private readonly Mock<IConfiguration> _configurationMock;
        private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
        private readonly HttpClient _httpClient;
        private readonly ShippingService _shippingService;

        public ShippingServiceTests()
        {
            _configurationMock = new Mock<IConfiguration>();
            _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            _httpClient = new HttpClient(_httpMessageHandlerMock.Object);
            _shippingService = new ShippingService(_configurationMock.Object, _httpClient);
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
    }
}
