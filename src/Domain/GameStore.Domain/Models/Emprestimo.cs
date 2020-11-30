using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.Domain.Models
{
    public class Emprestimo : Entity
    {
        public Amigo Amigo { get; set; }

        /* EF Relations */
        public IEnumerable<Jogo> Jogos { get; set; }
    }
}
