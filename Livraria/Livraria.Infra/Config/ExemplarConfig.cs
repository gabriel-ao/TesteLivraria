using Livraria.Infra.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Livraria.Infra.Config
{
    public class ExemplarConfig : IEntityTypeConfiguration<Exemplar>
    {
        public void Configure(EntityTypeBuilder<Exemplar> builder)
        {
            builder.ToTable("Exemplar");
            builder.HasKey(x => x.Id).HasName("Id_Exemplar");
            builder.Property(x => x.Id).HasColumnName("Id");

            builder.HasOne(l => l.Livro).WithMany(e => e.Exemplares).HasForeignKey(l => l.LivroId);
        }
    }
}
