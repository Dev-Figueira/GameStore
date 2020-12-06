namespace GameStore.Domain.Models
{
    public class Jogo : Entity
    {
        public string Nome { get; set; }
        public string Genero { get; set; }
        public bool Emprestado { get; set; }

        public Jogo() {}

        public Jogo(string nome, string genero, bool emprestado)
        {
            Nome = nome;
            Genero = genero;
            Emprestado = emprestado;
        }
    }
}
