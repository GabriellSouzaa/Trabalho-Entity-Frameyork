using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trabalho_23_08.Models
{
    [Table("Cursos")]
    public class Curso{

        [Key]
        public long id { get; set; }

        public char descricao { get; set; } = (char)30;
    
        public Curso() { } 
    }
}
