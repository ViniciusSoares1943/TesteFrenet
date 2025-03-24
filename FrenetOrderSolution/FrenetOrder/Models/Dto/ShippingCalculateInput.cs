namespace FrenetOrder.Models.Dto
{
    public class ShippingCalculateInput
    {
        public int CepOrigem { get; set; }
        public int CepDestino { get; set; }
        public string DocumentoDestinatario { get; set; }
        public decimal ValorPedido { get; set; }
        public List<ItemEnvio> ItemEnvio { get; set; }
    }

    public class ItemEnvio
    {
        public decimal Peso { get; set; }
        public decimal Largura { get; set; }
        public decimal Altura { get; set; }
        public decimal Cumprimento { get; set; }
        public decimal Diametro { get; set; }
        public bool Fragio { get; set; }
        public int Quantidade { get; set; }
        public string NomeProduto { get; set; }
    }
}
