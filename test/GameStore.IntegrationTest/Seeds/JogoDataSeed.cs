using GameStore.Data.Context;
using GameStore.Domain.Models;
using System;
using System.Collections.Generic;

namespace GameStore.IntegrationTest.Utils.Seeds
{
    public class JogoDataSeed : IDisposable
    {
        public GameStoreDbContex Context { get; private set; } = new GameStoreDbContex();

        public JogoDataSeed()
        {
            this.Context = ContextUtility.GetContext(); 

            List<Jogo> Games = new List<Jogo>()
            {
                new Jogo("Test Jogo 1", "Aventura", false),
                new Jogo("Test Jogo 2", "Guerra", false),
                new Jogo("Test Jogo 3", "Carro", true)
            };

            this.Context.AddRange(Games);
            this.Context.SaveChanges();
        }

        public void Dispose()
        {
            this.Context.Database.EnsureDeleted();
            this.Context.Dispose();
        }
    }
}
