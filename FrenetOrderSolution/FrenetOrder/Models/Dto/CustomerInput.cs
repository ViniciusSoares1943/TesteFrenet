namespace FrenetOrder.Models.Dto
{
    public class CustomerInput
    {
        /// <summary>
        /// Nome completo do cliente
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Endereço do cliente
        /// </summary>
        public string Endereco { get; set; }
        /// <summary>
        /// E-mail do cliente
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Telefone do cliente (contendo ddd)
        /// </summary>
        public string Telefone { get; set; }
    }
}
