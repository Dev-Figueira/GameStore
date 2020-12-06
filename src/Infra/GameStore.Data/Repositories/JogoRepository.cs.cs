using GameStore.Data.Context;
using GameStore.Domain.Interfaces;
using GameStore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Data.Repositories
{
    public class JogoRepository : Repository<Jogo>, IJogoRepository
    {
        public JogoRepository(GameStoreDbContex context) : base(context)
        {
        }

        public async Task<IEnumerable<Jogo>> ObterTodosNaoEmprestado()
        {
            return await Buscar(p => p.Emprestado == false);
        }
    }
}
