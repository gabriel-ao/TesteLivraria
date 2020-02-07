using Livraria.Infra.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Livraria.Infra.Config
{
    public class LivroConfig : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("Livro");
            builder.HasKey(x => x.Id).HasName("Id_Livro");
            builder.Property(x => x.Id).HasColumnName("Id");

            builder.HasOne(a => a.Autor).WithMany(l => l.Livros).HasForeignKey(a => a.AutorId) ;
        }
    }
}

