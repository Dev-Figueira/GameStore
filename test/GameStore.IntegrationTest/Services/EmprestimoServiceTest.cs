using GameStore.Domain.Interfaces;
using GameStore.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace GameStore.IntegrationTest.Services
{
    [TestClass()]
    public class EmprestimoServiceTest
    {
        [TestMethod()]
        public void AddTest()
        {
            var mock = new Mock<IEmprestimoService>();
            var emprestimo = new Emprestimo
            {
                Jogo = JogoCreate(),
                Amigo = AmigoCreate()
            };
            mock.Setup(e => e.Adicionar(emprestimo));
            mock.Object.Adicionar(emprestimo);
        }

        [TestMethod()]
        public void UpdateByIdTest()
        {
            var mock = new Mock<IEmprestimoService>();
            var emprestimo = new Emprestimo
            {
                Jogo = JogoCreate(),
                Amigo = AmigoCreate()
            };
            mock.Setup(e => e.Atualizar(emprestimo));
            mock.Object.Atualizar(emprestimo);
        }

        [TestMethod()]
        public void DeleteByIdTest()
        {
            var mock = new Mock<IEmprestimoService>();
            var guid = Guid.NewGuid();
            mock.Setup(e => e.Remover(guid));
            mock.Object.Remover(guid);
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
