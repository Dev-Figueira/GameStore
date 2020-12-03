using System;

namespace GameStore.Domain.Models
{
    public class Emprestimo : Entity
    {
        public Guid AmigoId { get; set; }
        public Amigo Amigo { get; set; }
        public Guid JogoId { get; set; }
        public Jogo Jogo { get; set; }
    }
}
