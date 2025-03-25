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

        public async Task<List<ShippingSevices>> ShippingCalculate(ShippingCalculateInput input)
        {
            if (input.CepDestino < 10000000 || input.CepDestino > 99999999)
            {
                throw new Exception("Cep de destino inválido!");
            }

            if (input.CepOrigem < 10000000 || input.CepOrigem > 99999999)
            {
                throw new Exception("Cep de origem inválido!");
            }

            if (input.ItemEnvio.Count == 0)
            {
                throw new Exception("Item de envio vazio!");
            }

            if (input.ItemEnvio.Any(x => x.Quantidade <= 0))
            {
                throw new Exception("Quantidade de item de envio inválida!");
            }

            var shippingQuoteResponse = await Calculate(input);

            if (
                shippingQuoteResponse == null 
                || shippingQuoteResponse.Body is null 
                || shippingQuoteResponse.Body.GetShippingQuoteResponse is null
                || shippingQuoteResponse.Body.GetShippingQuoteResponse.GetShippingQuoteResult is null
                || shippingQuoteResponse.Body.GetShippingQuoteResponse.GetShippingQuoteResult.ShippingSevicesArray.Count == 0)
            {
                throw new Exception("Erro ao calcular frete!");
            }

            return shippingQuoteResponse.Body.GetShippingQuoteResponse.GetShippingQuoteResult.ShippingSevicesArray;
        }

        private async Task<ShippingQuoteResponseEnvelope> Calculate(ShippingCalculateInput input)
        {
            
            var shippingQuoteRequest = new GetShippingQuoteRequest
            {
                QuoteRequest = new QuoteRequest
                {
                    Username = _configuration["Frenet:Username"] ?? throw new Exception("Erro interno ao integrar com api de cálculo de frete, credenciais não informadas"),
                    Password = _configuration["Frenet:Password"] ?? throw new Exception("Erro interno ao integrar com api de cálculo de frete, credenciais não informadas"),
                    SellerCEP = input.CepOrigem.ToString("00000-000"),
                    RecipientCEP = input.CepDestino.ToString("00000-000"),
                    RecipientDocument = input.DocumentoDestinatario,
                    ShipmentInvoiceValue = input.ValorPedido,
                    ShippingItemArray = input.ItemEnvio.Select(x => new ShippingItem 
                    {
                        Weight = x.Peso,
                        Length = x.Cumprimento,
                        Height = x.Altura,
                        Width = x.Largura,
                        Diameter = x.Diametro,
                        IsFragile = x.Fragio,
                        Quantity = x.Quantidade.ToString(),
                        ProductName = x.NomeProduto
                    }).ToList(),
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

            var xmlPayload = SerializeObjectToXml(body).Replace("soap_x003A_", "");

            var request = new HttpRequestMessage(HttpMethod.Post, _configuration["Frenet:Url"] + _configuration["Frenet:ShippingQuotePath"])
            {
                Content = new StringContent(xmlPayload, Encoding.UTF8, "text/xml")
            };

            request.Headers.Add("SOAPAction", _configuration["Frenet:SoapActionQuote"]);
            request.Headers.Add("Authorization", _configuration["Frenet:Token"]);

            var httpClient = new HttpClient();
            var response = await httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            try
            {
                var shippingQuorte = DeserializeSoapResponse(responseString);
                return shippingQuorte;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro interno ao ler resposta da api de fretes");
            }
        }

        public string SerializeObjectToXml(object obj)
        {
            var serializer = new XmlSerializer(obj.GetType());

            using var memoryStream = new MemoryStream();
            serializer.Serialize(memoryStream, obj);
            return Encoding.UTF8.GetString(memoryStream.ToArray());
        }


        public ShippingQuoteResponseEnvelope DeserializeSoapResponse(string xml)
        {
            var serializer = new XmlSerializer(typeof(ShippingQuoteResponseEnvelope));

            var reader = new StringReader(xml);

            var ns = new XmlSerializerNamespaces();
            ns.Add("soap", "http://schemas.xmlsoap.org/soap/envelope/");
            ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            ns.Add("xsd", "http://www.w3.org/2001/XMLSchema");

            var response = serializer.Deserialize(reader);
            return response as ShippingQuoteResponseEnvelope ?? throw new Exception("Erro interno ao ler resposta da api de fretes");
        }
    }
}