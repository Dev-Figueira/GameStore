using System;

namespace GameStore.Domain.Models
{
    public class Amigo : Entity
    {
        public Guid EmprestimoId { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string Email { get; set; }

        /* EF Relation */
        public Emprestimo Emprestimo { get; set; }
    }
}
