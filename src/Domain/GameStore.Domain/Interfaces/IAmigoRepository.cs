using GameStore.Domain.Models;
using System;
using System.Threading.Tasks;

namespace GameStore.Domain.Interfaces
{
    public interface IAmigoRepository : IRepository<Amigo>
    {
        Task<Amigo> ObterAmigoPorEmprestimo(Guid id);
    }
}
