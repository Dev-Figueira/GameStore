using GameStore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStore.Data.Mappings
{
    public class AmigoMapping : IEntityTypeConfiguration<Amigo>
    {
        public void Configure(EntityTypeBuilder<Amigo> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Apelido)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(c => c.Email)
                .HasColumnType("varchar(250)");

            builder.ToTable("Amigos");
        }
    }
}
