using GameStore.Data.Context;
using GameStore.Domain.Interfaces;
using GameStore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Data.Repositories
{
    public class JogoRepository : Repository<Jogo>, IJogoRepository
    {
        public JogoRepository(GameStoreDbContex context) : base(context)
        {
        }
    }
}
