using System.Xml.Serialization;

namespace FrenetOrder.Models.Dto
{

    [XmlRoot("Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class ShippingQuoteResponseEnvelope
    {
        [XmlElement("Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public ShippingQuoteResponseBody Body { get; set; }
    }

    public class ShippingQuoteResponseBody
    {
        [XmlElement("GetShippingQuoteResponse", Namespace = "http://tempuri.org/")]
        public GetShippingQuoteResponse GetShippingQuoteResponse { get; set; }
    }

    public class GetShippingQuoteResponse
    {
        [XmlElement("GetShippingQuoteResult")]
        public GetShippingQuoteResult GetShippingQuoteResult { get; set; }
    }

    public class GetShippingQuoteResult
    {
        [XmlArray("ShippingSevicesArray")]
        [XmlArrayItem("ShippingSevices")]
        public List<ShippingSevices> ShippingSevicesArray { get; set; }
    }

    public class ShippingSevices
    {
        [XmlElement("ServiceID")]
        public int ServiceID { get; set; }

        [XmlElement("ServiceCode")]
        public string ServiceCode { get; set; }

        [XmlElement("ServiceDescription")]
        public string ServiceDescription { get; set; }

        [XmlElement("Carrier")]
        public string Carrier { get; set; }

        [XmlElement("ShippingPrice")]
        public decimal? ShippingPrice { get; set; }

        [XmlElement("OriginalShippingPrice")]
        public decimal? OriginalShippingPrice { get; set; }

        [XmlElement("DeliveryTime")]
        public int? DeliveryTime { get; set; }

        [XmlElement("OriginalDeliveryTime")]
        public int? OriginalDeliveryTime { get; set; }

        [XmlElement("ResponseTime")]
        public decimal ResponseTime { get; set; }

        [XmlElement("Error")]
        public bool Error { get; set; }

        [XmlElement("AllowBuyLabel")]
        public bool AllowBuyLabel { get; set; }

        [XmlElement("OwnerContract")]
        public bool OwnerContract { get; set; }

        [XmlElement("FrenetContract")]
        public bool FrenetContract { get; set; }

        [XmlElement("DeliveryBranchOfficeCarrierId")]
        public int DeliveryBranchOfficeCarrierId { get; set; }

        [XmlElement("ShippingPriceCarrier")]
        public decimal ShippingPriceCarrier { get; set; }

        [XmlElement("ProtectionValue")]
        public decimal ProtectionValue { get; set; }

        [XmlElement("PresentationalPrice")]
        public decimal PresentationalPrice { get; set; }

        [XmlElement("Msg")]
        public string? Msg { get; set; }
    }


}
