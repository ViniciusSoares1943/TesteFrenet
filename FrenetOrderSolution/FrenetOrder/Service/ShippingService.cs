using System.Text;
using FrenetOrder.Models.Dto;
using System.Xml.Serialization;
using FrenetOrder.Service.Interface;

namespace FrenetOrder.Service
{
    public class ShippingService : IShippingService
    {
        private readonly IConfiguration _configuration;

        public ShippingService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> Calculate()
        {
            var httpClient = new HttpClient();


            // Criação da entidade
            var shippingQuoteRequest = new GetShippingQuoteRequest
            {
                quoteRequest = new QuoteRequest
                {
                    Username = _configuration["Frenet:Username"],
                    Password = _configuration["Frenet:Password"],
                    SellerCEP = "01001-000",
                    RecipientCEP = "20031-170",
                    RecipientDocument = "12345678900",
                    ShipmentInvoiceValue = 100.00M,
                    ShippingItemArray = new List<ShippingItem>
                    {
                        new ShippingItem
                        {
                            Weight = 1.5M,
                            Length = 20M,
                            Height = 10M,
                            Width = 15M,
                            Diameter = 5M,
                            IsFragile = false,
                            Quantity = "1",
                            ProductName = "Produto Exemplo"
                        }
                    },
                    RecipientCountry = "BR",
                    IsCubicWeight = true
                }
            };

            var body = new SoapEnvelope
            {
                Body = new SoapBody
                {
                    GetShippingQuoteRequest = shippingQuoteRequest
                }
            };

            // Serializar o objeto para XML
            var xmlPayload = SerializeObjectToXml(body).Replace("soap_x003A_", "");

            // Criar a requisição HTTP
            var request = new HttpRequestMessage(HttpMethod.Post, _configuration["Frenet:Url"] + _configuration["Frenet:ShippingQuotePath"])
            {
                Content = new StringContent(xmlPayload, Encoding.UTF8, "text/xml")
            };

            // Adicionar o cabeçalho SOAPAction
            request.Headers.Add("SOAPAction", _configuration["Frenet:SoapActionQuote"]);
            request.Headers.Add("Authorization", _configuration["Frenet:Token"]);

            // Enviar a requisição e obter a resposta
            var response = await httpClient.SendAsync(request);

            // Garantir que a resposta foi bem-sucedida
            response.EnsureSuccessStatusCode();

            // Ler a resposta como string
            var responseString = await response.Content.ReadAsStringAsync();

            return responseString;
        }

        public string SerializeObjectToXml(object obj)
        {
            var serializer = new XmlSerializer(obj.GetType());

            using (var memoryStream = new MemoryStream())
            {
                serializer.Serialize(memoryStream, obj);
                return Encoding.UTF8.GetString(memoryStream.ToArray());
            }
        }
    }
}