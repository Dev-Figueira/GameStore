using GameStore.Data.Repositories;
using GameStore.Domain.Models;
using GameStore.IntegrationTest.Utils.Seeds;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace JogoStore.IntegrationTest.Infra.Repositories
{
    [TestClass]
    public class JogoRepositoryTest
    {
        private JogoRepository Repository { get; set; }
        public JogoDataSeed Seed { get; set; }

        [TestInitialize]
        public void Setup()
        {
            Seed = new JogoDataSeed();
            Repository = new JogoRepository(Seed.Context);
        }

        [TestCleanup]
        public void CleanUp()
        {
            this.Seed.Dispose();
        }

        [TestMethod]
        public void TestFindById()
        {
            Jogo jogo = Repository.Buscar(j => j.Nome == "Test Jogo 1").Result.FirstOrDefault();

            Assert.IsNotNull(jogo);
        }

        [TestMethod]
        public void TestGetAll()
        {
            var jogos = Repository.ObterTodos();

            Assert.IsNotNull(jogos);
            Assert.AreEqual(3, jogos.Result.ToList().Count);
        }

        [TestMethod]
        public void TestSave()
        {
            Jogo jogo = new Jogo("New Jogo", "Guerra", false);
            Repository.Adicionar(jogo);
            this.Seed.Context.SaveChanges();

            Assert.IsNotNull(jogo.Id);
            Assert.AreEqual(4, this.Repository.DbSet.Count());
        }

        [TestMethod]
        public void TestUpdate()
        {
            Jogo jogo = Repository.Buscar(j => j.Nome == "Test Jogo 2").Result.FirstOrDefault();
            jogo.Nome = "Jogo B";

            this.Repository.Atualizar(jogo);
            this.Seed.Context.SaveChanges();

            Jogo jogoAtualizado  = this.Repository.Buscar(j => j.Nome == "Jogo B").Result.FirstOrDefault();
            Assert.IsNotNull(jogoAtualizado.Nome);
            Assert.AreEqual(jogoAtualizado.Nome, "Jogo B");
        }

        [TestMethod]
        public void TestDelete()
        {
            Jogo jogo = Repository.Buscar(j => j.Nome == "Test Jogo 1").Result.FirstOrDefault();
            this.Repository.RemoverWithDetachLocal(jogo.Id);
            this.Seed.Context.SaveChanges();

            Assert.AreEqual(2, this.Repository.DbSet.Count());
        }
    }
}
