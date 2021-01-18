
using Curso.Api.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Curso.Api.Infraestruture.Data.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("TB_USUARIO");
            builder.HasKey(prop => prop.Codigo);
            builder.Property(prop => prop.Codigo).ValueGeneratedOnAdd();
            builder.Property(prop => prop.Login);
            builder.Property(prop => prop.Senha);
            builder.Property(prop => prop.Email);
        }
    }
}
