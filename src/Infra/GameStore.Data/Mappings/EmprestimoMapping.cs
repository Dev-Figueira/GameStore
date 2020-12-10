using GameStore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStore.Data.Mappings
{
    public class EmprestimoMapping : IEntityTypeConfiguration<Emprestimo>
    {
        public void Configure(EntityTypeBuilder<Emprestimo> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(a => a.AmigoId);

            builder.Property(h => h.JogoId);

            builder.HasOne(h => h.Amigo)
                .WithMany().HasForeignKey(h => h.AmigoId);

            builder.HasOne(h => h.Jogo)
                .WithMany().HasForeignKey(h => h.JogoId);

            builder.ToTable("Emprestimos");
        }
    }
}
