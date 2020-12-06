using GameStore.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameStore.UnitTests.Domain
{
    [TestClass]
    class JogosTest
    {
        [TestMethod]
        public void TestCreate()
        {
            Jogo jogo = Jogo();

            Assert.IsNotNull(jogo);
            Assert.IsNotNull(jogo.Nome);
            Assert.IsNotNull(jogo.Genero);
            Assert.IsNotNull(jogo.Emprestado);
        }

        public Jogo Jogo()
        {
            Jogo jogo = new Jogo("Ratchet & Clank",
                                 "Ratchet & Clank é o ponto culminante de tudo o que a Insomniac fez com a clássica franquia nos últimos 14 anos.",
                                 false);
            return jogo;
        }
    }
}
