using GameStore.Data.Context;
using GameStore.Domain.Interfaces;
using GameStore.Domain.Models;

namespace GameStore.Data.Repositories
{
    public class JogoRepository : Repository<Jogo>, IJogoRepository
    {
        public JogoRepository(GameStoreDbContex context) : base(context)
        {
        }
    }
}
