using GameStore.Domain.Models;
using System;
using System.Threading.Tasks;

namespace GameStore.Domain.Interfaces
{
    public interface IEmprestimoRepository : IRepository<Emprestimo>
    {
        Task<Emprestimo> ObterEmprestimoAmigo(Guid id);
        Task<object> ObterEmprestimoJogosAmigo();
        Task<Emprestimo> ObterEmprestimoJogosAmigo(Guid id);

    }
}
