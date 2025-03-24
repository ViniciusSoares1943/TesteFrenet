using System.ComponentModel.DataAnnotations.Schema;

namespace FrenetOrder.Models.Entity
{
    [Table("Usuarios")]
    public class User
    {
        /// <summary>
        /// Identificador do usuário
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Login do usuário
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Senha do usuário
        /// </summary>
        public string Senha { get; set; }
    }
}
