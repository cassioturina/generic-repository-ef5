using generic_repository_ef5.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace generic_repository_ef5.Data
{
    public class AutorConfiguracao : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.ToTable("Autores");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasMaxLength(120).HasColumnType("varchar(120)").IsRequired();
            builder.HasMany(x => x.Livros).WithMany(x => x.Autores);
        }
    }
}
