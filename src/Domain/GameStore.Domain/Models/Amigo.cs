namespace GameStore.Domain.Models
{
    public class Amigo : Entity
    {
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string Email { get; set; }

        public Amigo() { }

        public Amigo(string nome, string apelido, string email)
        {
            Nome = nome;
            Apelido = apelido;
            Email = email;
        }
    }
}
