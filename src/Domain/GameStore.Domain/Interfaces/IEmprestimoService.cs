using GameStore.Domain.Models;
using System;
using System.Threading.Tasks;

namespace GameStore.Domain.Interfaces
{
    public interface IEmprestimoService : IDisposable
    {
        Task Adicionar(Emprestimo emprestimo);
        Task Atualizar(Emprestimo emprestimo);
        Task Remover(Guid id);

        Task AtualizarAmigo(Amigo amigo);
        Task AtualizarJogo(Jogo jogo);
    }
}
