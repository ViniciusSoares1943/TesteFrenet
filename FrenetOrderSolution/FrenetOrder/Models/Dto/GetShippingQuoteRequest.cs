using System.Xml.Serialization;
namespace FrenetOrder.Models.Dto
{
    [XmlRoot("soap:Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class SoapEnvelope
    {
        [XmlElement("soap:Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public SoapBody Body { get; set; }
    }

    public class SoapBody
    {
        [XmlElement("GetShippingQuote", Namespace = "http://tempuri.org/")]
        public GetShippingQuoteRequest GetShippingQuoteRequest { get; set; }
    }

    public class GetShippingQuoteRequest
    {
        [XmlElement("quoteRequest")]
        public QuoteRequest quoteRequest { get; set; }
    }

    public class QuoteRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string SellerCEP { get; set; }
        public string RecipientCEP { get; set; }
        public string RecipientDocument { get; set; }
        public decimal ShipmentInvoiceValue { get; set; }
        public List<ShippingItem> ShippingItemArray { get; set; }
        public string RecipientCountry { get; set; }
        public bool IsCubicWeight { get; set; }
    }

    public class ShippingItem
    {
        public decimal Weight { get; set; }
        public decimal Length { get; set; }
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public decimal Diameter { get; set; }
        public bool IsFragile { get; set; }
        public string Quantity { get; set; }
        public string ProductName { get; set; }
    }
}