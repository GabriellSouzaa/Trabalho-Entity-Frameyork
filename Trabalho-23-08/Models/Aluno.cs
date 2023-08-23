using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trabalho_23_08.Models
{

    [Table("Alunos")]
    public class Aluno {

        [Key]
        public int id { get; set; }

        public char nome { get; set; } = (char)35;

        public DateTime aniversario { get; set; }

        public Curso curso;

        public string periodo;
        
        public Aluno() { }  

    }
}
