using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trabalho_23_08.Models
{
    [Table("Salas")]
    public class Sala {

        [Key]
        public long id { get; set; }

        public char descricao { get; set; } = (char)20; 

        public long equipamentos { get; set; }  

        public char situacao { get; set; } = (char)20;
    }
}
