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

    /// <summary>
    /// Serviços de frete
    /// </summary>
    public class ShippingSevices
    {
        /// <summary>
        /// ID do serviço
        /// </summary>
        [XmlElement("ServiceID")]
        public int ServiceID { get; set; }
        /// <summary>
        /// Código do serviço
        /// </summary>
        [XmlElement("ServiceCode")]
        public string ServiceCode { get; set; }
        /// <summary>
        /// Descrição do serviço
        /// </summary>
        [XmlElement("ServiceDescription")]
        public string ServiceDescription { get; set; }
        /// <summary>
        /// Transportadora
        /// </summary>
        [XmlElement("Carrier")]
        public string Carrier { get; set; }
        /// <summary>
        /// Preço de envio
        /// </summary>
        [XmlElement("ShippingPrice")]
        public decimal? ShippingPrice { get; set; }
        /// <summary>
        /// Preço de envio original
        /// </summary>
        [XmlElement("OriginalShippingPrice")]
        public decimal? OriginalShippingPrice { get; set; }
        /// <summary>
        /// Tempo de entrega
        /// </summary>
        [XmlElement("DeliveryTime")]
        public int? DeliveryTime { get; set; }
        /// <summary>
        /// Tempo de entrega original
        /// </summary>
        [XmlElement("OriginalDeliveryTime")]
        public int? OriginalDeliveryTime { get; set; }
        /// <summary>
        /// Tempo de resposta
        /// </summary>
        [XmlElement("ResponseTime")]
        public decimal ResponseTime { get; set; }
        /// <summary>
        /// Erro
        /// </summary>
        [XmlElement("Error")]
        public bool Error { get; set; }
        /// <summary>
        /// Permit comprar etiqueta
        /// </summary>
        [XmlElement("AllowBuyLabel")]
        public bool AllowBuyLabel { get; set; }
        /// <summary>
        /// Proprietário do contrato
        /// </summary>
        [XmlElement("OwnerContract")]
        public bool OwnerContract { get; set; }
        /// <summary>
        /// Contrato da Frenet
        /// </summary>
        [XmlElement("FrenetContract")]
        public bool FrenetContract { get; set; }
        /// <summary>
        /// ID da filial de entrega
        /// </summary>
        [XmlElement("DeliveryBranchOfficeCarrierId")]
        public int DeliveryBranchOfficeCarrierId { get; set; }
        /// <summary>
        /// Preço da transportadora
        /// </summary>
        [XmlElement("ShippingPriceCarrier")]
        public decimal ShippingPriceCarrier { get; set; }
        /// <summary>
        /// Preço de envio com seguro
        /// </summary>
        [XmlElement("ProtectionValue")]
        public decimal ProtectionValue { get; set; }
        /// <summary>
        /// Preço apresentacional
        /// </summary>
        [XmlElement("PresentationalPrice")]
        public decimal PresentationalPrice { get; set; }
        /// <summary>
        /// Mensagem de erro
        /// </summary>
        [XmlElement("Msg")]
        public string? Msg { get; set; }
    }
}
