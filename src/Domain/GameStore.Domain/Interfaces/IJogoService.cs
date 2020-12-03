using GameStore.Domain.Models;
using System;
using System.Threading.Tasks;

namespace GameStore.Domain.Interfaces
{
    public interface IJogoService : IDisposable
    {
        Task Adicionar(Jogo jogo);
        Task Atualizar(Jogo jogo);
        Task Remover(Guid id);
    }
}
