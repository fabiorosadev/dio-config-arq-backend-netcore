using Curso.Api.Business.Entities;
using Curso.Api.Infraestruture.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Curso.Api.Infraestruture.Data
{
    public class CursoDbContext : DbContext
    {
        public CursoDbContext(DbContextOptionsBuilder<CursoDbContext> options) : base(options.Options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CursoMapping());
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Curso> Cursos { get; set; }
    }
}
