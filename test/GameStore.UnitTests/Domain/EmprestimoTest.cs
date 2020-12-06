using GameStore.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameStore.UnitTests.Domain
{
    [TestClass]
    public class EmprestimoTest
    {
        [TestMethod]
        public void TestCreate()
        {
            Amigo amigo = AmigoCreate();
            Jogo jogo = JogoCreate();

            Emprestimo emprestimo = new Emprestimo(amigo, jogo);

            Assert.IsNotNull(emprestimo);
            Assert.IsNotNull(emprestimo.Amigo);
            Assert.IsNotNull(emprestimo.Jogo);
        }

        public Jogo JogoCreate()
        {
            Jogo jogo = new Jogo("Ratchet & Clank",
                                 "Ratchet & Clank é o ponto culminante de tudo o que a Insomniac fez com a clássica franquia nos últimos 14 anos.",
                                 false);
            return jogo;
        }

        public Amigo AmigoCreate()
        {
            Amigo amigo = new Amigo("Zé Rodrigo", "zezinho", "ze.rodrigo@gmail.com");
            return amigo;
        }
    }
}
