using System.ComponentModel.DataAnnotations.Schema;

namespace FrenetOrder.Models.Entity
{
    [Table("Usuarios")]
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
