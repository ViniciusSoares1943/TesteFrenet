using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FrenetOrder.Models.Entity
{
    public class Customer
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Endereco { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
