using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Curso.Api.Infraestruture.Data.Mappings
{
    public class CursoMapping : IEntityTypeConfiguration<Business.Entities.Curso>
    {
        public void Configure(EntityTypeBuilder<Business.Entities.Curso> builder)
        {
            builder.ToTable("TB_CURSO");
            builder.HasKey(prop => prop.Codigo);
            builder.Property(prop => prop.Codigo).ValueGeneratedOnAdd();
            builder.Property(prop => prop.Nome);
            builder.Property(prop => prop.Descricao);
            builder.HasOne(p => p.Usuario)
                .WithMany()
                .HasForeignKey(fk => fk.CodigoUsuario);
        }
    }
}
