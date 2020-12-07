using GameStore.Domain.Interfaces;
using GameStore.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace GameStore.IntegrationTest.Services
{
    [TestClass()]
    public class JogoServiceTests
    {
        [TestMethod()]
        public void AddTest()
        {
            var mock = new Mock<IJogoService>();
            var jogoViewModel = new Jogo
            {
                Nome = "Jogo 1",
                Genero = "Guerra",
                Emprestado = false,
            };
            mock.Setup(e => e.Adicionar(jogoViewModel));
            mock.Object.Adicionar(jogoViewModel);
        }

        [TestMethod()]
        public void UpdateByIdTest()
        {
            var mock = new Mock<IJogoService>();
            var guid = Guid.NewGuid();
            var jogoViewModel = new Jogo
            {
                Nome = "Jogo 1",
                Genero = "Guerra",
                Emprestado = false,
            };
            mock.Setup(e => e.Atualizar(jogoViewModel));
            mock.Object.Atualizar(jogoViewModel);
        }

        [TestMethod()]
        public void DeleteByIdTest()
        {
            var mock = new Mock<IJogoService>();
            var guid = Guid.NewGuid();
            mock.Setup(e => e.Remover(guid));
            mock.Object.Remover(guid);
        }
    }
}
