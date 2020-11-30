using GameStore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStore.Data.Mappings
{
    public class JogoMapping : IEntityTypeConfiguration<Jogo>
    {
        public void Configure(EntityTypeBuilder<Jogo> builder)
        {
            builder.HasKey(j => j.Id);

            builder.Property(j => j.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(j => j.Genero)
                 .IsRequired()
                 .HasColumnType("varchar(100)");

            builder.ToTable("Jogos");
        }
    }
}
