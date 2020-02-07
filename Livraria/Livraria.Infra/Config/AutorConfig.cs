using Livraria.Infra.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Livraria.Infra.Config
{
    public class AutorConfig : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {

            builder.ToTable("Autor");
            builder.HasKey(x => x.Id).HasName("Id_Autor");
            builder.Property(x => x.Id).HasColumnName("Id");
        }
    }
}
