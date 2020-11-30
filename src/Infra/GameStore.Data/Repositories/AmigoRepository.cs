using GameStore.Data.Context;
using GameStore.Domain.Interfaces;
using GameStore.Domain.Models;

namespace GameStore.Data.Repositories
{
    public class AmigoRepository : Repository<Amigo>, IAmigoRepository
    {
        public AmigoRepository(GameStoreDbContex context) : base(context)
        {
        }
    }
}