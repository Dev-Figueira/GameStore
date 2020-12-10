using GameStore.Data.Context;
using GameStore.Domain.Interfaces;
using GameStore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace GameStore.Data.Repositories
{
    public class EmprestimoRepository : Repository<Emprestimo>, IEmprestimoRepository
    {
        public EmprestimoRepository(GameStoreDbContex context) : base(context)
        {
        }

        public async Task<Emprestimo> ObterEmprestimoAmigo(Guid id)
        {
            return await Db.Emprestimos.AsNoTracking()
                .Include(c => c.Amigo)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<object> ObterEmprestimoJogosAmigo()
        {
            return await Db.Emprestimos.AsNoTracking()
                .Include(j => j.Jogo)
                .Include(a => a.Amigo).ToListAsync();
        }

        public async Task<Emprestimo> ObterEmprestimoJogosAmigo(Guid id)
        {
            return await Db.Emprestimos.AsNoTracking()
                .Include(j => j.Jogo)
                .Include(a => a.Amigo)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}