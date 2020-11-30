using GameStore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStore.Data.Models
{
    public class EmprestimoMapping : IEntityTypeConfiguration<Emprestimo>
    {
        public void Configure(EntityTypeBuilder<Emprestimo> builder)
        {
            builder.HasKey(e => e.Id);

            // 1 : 1 => Emprestimo : Amigo
            builder.HasOne(e => e.Amigo)
                .WithOne(a => a.Emprestimo);

            // 1 : N => Emprestimo : Jogo
            builder.HasMany(f => f.Jogos)
                .WithOne(e => e.Emprestimo)
                .HasForeignKey(e => e.EmprestimoId);

            builder.ToTable("Emprestimos");
        }
    }
}
