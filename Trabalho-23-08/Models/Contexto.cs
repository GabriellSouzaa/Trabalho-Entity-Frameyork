using Microsoft.EntityFrameworkCore;

namespace Trabalho_23_08.Models
{
    public class Contexto : DbContext {

        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Aluno> alunos {get; set;}

        public DbSet<Atendimento> atendimentos { get; set; }

        public DbSet<Curso> cursos { get; set; }

        public DbSet<Sala> salas { get; set; }
    }
}
