using generic_repository_ef5.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace generic_repository_ef5.Data
{
    public class LivroConfiguracao : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("Livros");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Titulo).HasMaxLength(120).HasColumnType("varchar(120)").IsRequired();
            builder.HasMany(x => x.Autores).WithMany(x => x.Livros);
        }
    }
}
