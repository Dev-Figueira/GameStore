using GameStore.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace GameStore.IntegrationTest.Utils
{
    public static class ContextUtility
    {
        public static string DATABASE_NAME => "InVillia";

        /// <summary>
        /// Retorna build com opções para construção do contexto
        /// </summary>
        /// <typeparam name="TContext">Tipo do contexto</typeparam>
        /// <returns>DbContextOptions</returns>
        public static DbContextOptions<TContext> GetOptions<TContext>() where TContext : DbContext
        {
            DbContextOptionsBuilder<TContext> builder = new DbContextOptionsBuilder<TContext>()
                .UseInMemoryDatabase(databaseName: DATABASE_NAME)
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .EnableSensitiveDataLogging(true);

            return builder.Options;
        }

        /// <summary>
        /// Retorna Objeto de Contexto com opções configuradas
        /// </summary>
        /// <returns></returns>
        public static GameStoreDbContex GetContext()
        {
            DbContextOptions<GameStoreDbContex> options = GetOptions<GameStoreDbContex>();
            return new GameStoreDbContex(options);
        }
    }
}
