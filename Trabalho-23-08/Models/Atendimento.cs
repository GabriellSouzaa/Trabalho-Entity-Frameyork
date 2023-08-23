using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trabalho_23_08.Models
{
    [Table("Atendimentos")]
    public class Atendimento{

        [Key]
        public long id { get; set; }

        public Aluno aluno;

        public Sala sala;

        public DateTime data { get; set; }

        public string hora { get; set; }

        public Atendimento() { }
    }
}
