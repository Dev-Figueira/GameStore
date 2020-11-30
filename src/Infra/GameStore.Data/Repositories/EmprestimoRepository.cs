using GameStore.Data.Context;
using GameStore.Domain.Interfaces;
using GameStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.Data.Repositories
{
    public class EmprestimoRepository : Repository<Emprestimo>, IEmprestimoRepository
    {
        public EmprestimoRepository(GameStoreDbContex context) : base(context)
        {
        }
    }
}