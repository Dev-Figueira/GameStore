using GameStore.Data.Context;
using GameStore.Domain.Interfaces;
using GameStore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace GameStore.Data.Repositories
{
    public class AmigoRepository : Repository<Amigo>, IAmigoRepository
    {
        public AmigoRepository(GameStoreDbContex context) : base(context)
        {
        }

        public async Task<Amigo> ObterAmigoPorEmprestimo(Guid emprestimoId)
        {
            var amigo = await Db.Emprestimos.AsNoTracking()
                 .FirstOrDefaultAsync(f => f.Id == emprestimoId);

            return await Db.Amigos.AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == amigo.Id);

        }
    }
}