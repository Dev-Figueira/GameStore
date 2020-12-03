using GameStore.Domain.Models;
using System;
using System.Threading.Tasks;

namespace GameStore.Domain.Interfaces
{
    public interface IAmigoService : IDisposable
    {
        Task Adicionar(Amigo amigo);
        Task Atualizar(Amigo amigo);
        Task Remover(Guid id);
    }
}
