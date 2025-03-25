namespace FrenetOrder.Models.Dto
{
    /// <summary>
    /// Parametros para calculo de frete
    /// </summary>
    public class ShippingCalculateInput
    {
        /// <summary>
        /// CEP de origem (somente numericos)
        /// </summary>
        public string CepOrigem { get; set; }
        /// <summary>
        /// CEP de destino (somente numericos)
        /// </summary>
        public string CepDestino { get; set; }
        /// <summary>
        /// Documento do destinatario
        /// </summary>
        public string DocumentoDestinatario { get; set; }
        /// <summary>
        /// Valor do pedido
        /// </summary>
        public decimal ValorPedido { get; set; }
        /// <summary>
        /// Lista de itens
        /// </summary>
        public List<ItemEnvio> ItemEnvio { get; set; }
    }

    /// <summary>
    /// Item de envio
    /// </summary>
    public class ItemEnvio
    {
        /// <summary>
        /// Peso do item
        /// </summary>
        public decimal Peso { get; set; }
        /// <summary>
        /// Largura do item
        /// </summary>
        public decimal Largura { get; set; }
        /// <summary>
        /// Altura do item
        /// </summary>
        public decimal Altura { get; set; }
        /// <summary>
        /// Cumprimento do item
        /// </summary>
        public decimal Cumprimento { get; set; }
        /// <summary>
        /// Diametro do item
        /// </summary>
        public decimal Diametro { get; set; }
        /// <summary>
        /// Item frágio - true para sim, false para não
        /// </summary>
        public bool Fragio { get; set; }
        /// <summary>
        /// Quantidade do item
        /// </summary>
        public int Quantidade { get; set; }
        /// <summary>
        /// Nome do produto
        /// </summary>
        public string NomeProduto { get; set; }
    }
}
