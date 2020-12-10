using GameStore.Domain.Interfaces;
using GameStore.Domain.Models;
using GameStore.Domain.Models.Validations;
using System;
using System.Threading.Tasks;

namespace GameStore.WebApp.MVC.Services
{
    public class JogoService : Service, IJogoService
    {
        private readonly IJogoRepository _jogoRepository;

        public JogoService(IJogoRepository jogoRepository,
                              INotificador notificador) : base(notificador)
        {
            _jogoRepository = jogoRepository;
        }

        public async Task Adicionar(Jogo jogo)
        {
            if (!ExecutarValidacao(new JogoValidation(), jogo)) return;

            await _jogoRepository.Adicionar(jogo);
        }

        public async Task Atualizar(Jogo jogo)
        {
            if (!ExecutarValidacao(new JogoValidation(), jogo)) return;

            await _jogoRepository.Atualizar(jogo);
        }

        public async Task Remover(Guid id)
        {
            await _jogoRepository.RemoverWithDetachLocal(id);
        }

        public void Dispose()
        {
            _jogoRepository?.Dispose();
        }
    }
}
