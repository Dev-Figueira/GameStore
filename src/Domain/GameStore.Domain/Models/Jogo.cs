using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.Domain.Models
{
    public class Jogo : Entity
    {
        //public Guid EmprestimoId { get; set; }
        public string Nome { get; set; }
        public string Genero { get; set; }

        /* EF Relations */
        //public Emprestimo Emprestimo { get; set; }  
    }
}
