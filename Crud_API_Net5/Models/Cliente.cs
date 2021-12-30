using System.ComponentModel.DataAnnotations;

namespace Crud_API_Net5.Models
{
    public class Cliente
    {
        [Key]
        public int id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set;}
    }
}
