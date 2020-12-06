using GameStore.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameStore.UnitTests.Domain
{
    [TestClass]
    public class AmigoTest
    {
        [TestMethod]
        public void TestCreate()
        {
            Amigo amigo = Amigo();

            Assert.IsNotNull(amigo);
            Assert.IsNotNull(amigo.Id);
            Assert.IsNotNull(amigo.Apelido);
            Assert.IsNotNull(amigo.Email);
            Assert.IsNotNull(amigo.Nome);
        }

        public Amigo Amigo()
        {
            Amigo amigo = new Amigo("Zé Rodrigo", "zezinho", "ze.rodrigo@gmail.com");
            return amigo;
        }
    }
}
