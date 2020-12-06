using GameStore.Domain.Interfaces;
using GameStore.Domain.Models;
using GameStore.Domain.Models.Validations;
using System;
using System.Threading.Tasks;

namespace GameStore.WebApp.MVC.Services
{
    public class JogoService : Service, IJogoService
    {
        private readonly IJogoRepository _JogoRepository;

        public JogoService(IJogoRepository JogoRepository,
                              INotificador notificador) : base(notificador)
        {
            _JogoRepository = JogoRepository;
        }

        public async Task Adicionar(Jogo jogo)
        {
            if (!ExecutarValidacao(new JogoValidation(), jogo)) return;

            await _JogoRepository.Adicionar(jogo);
        }

        public async Task Atualizar(Jogo jogo)
        {
            if (!ExecutarValidacao(new JogoValidation(), jogo)) return;

            await _JogoRepository.Atualizar(jogo);
        }

        public async Task Remover(Guid id)
        {
            await _JogoRepository.RemoverWithDetachLocal(id);
        }

        public void Dispose()
        {
            _JogoRepository?.Dispose();
        }
    }
}
