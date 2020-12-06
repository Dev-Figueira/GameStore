using GameStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Domain.Interfaces
{
    public interface IJogoRepository : IRepository<Jogo>
    {
        Task<IEnumerable<Jogo>> ObterTodosNaoEmprestado();
    }
}
