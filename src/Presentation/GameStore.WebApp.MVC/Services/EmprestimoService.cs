using GameStore.Domain.Interfaces;
using GameStore.Domain.Models;
using GameStore.Domain.Models.Validations;
using System;
using System.Threading.Tasks;

namespace GameStore.WebApp.MVC.Services
{
    public class EmprestimoService : Service, IEmprestimoService
    {
        private readonly IEmprestimoRepository _emprestimoRepository;
        private readonly IAmigoRepository _amigoRepository;
        private readonly IJogoRepository _jogoRepository;

        public EmprestimoService(IEmprestimoRepository emprestimoRepository,
                                 IAmigoRepository amigoRepository,
                                 IJogoRepository jogoRepository,
                                 INotificador notificador) : base(notificador)
        {
            _emprestimoRepository = emprestimoRepository;
            _amigoRepository = amigoRepository;
            _jogoRepository = jogoRepository;
        }

        public async Task Adicionar(Emprestimo emprestimo)
        {
            if (!ExecutarValidacao(new EmprestimoValidation(), emprestimo)
                || !ExecutarValidacao(new AmigoValidation(), emprestimo.Amigo)) return;

            emprestimo.Jogo.Emprestado = true;
            await _jogoRepository.Atualizar(emprestimo.Jogo);

            if (emprestimo.Amigo.Id == Guid.Empty)
            {
                await _amigoRepository.Adicionar(emprestimo.Amigo);
            }

            await _emprestimoRepository.Adicionar(emprestimo);
        }

        public async Task Atualizar(Emprestimo emprestimo)
        {
            if (!ExecutarValidacao(new EmprestimoValidation(), emprestimo)) return;

            await _emprestimoRepository.Atualizar(emprestimo);
        }

        public async Task AtualizarAmigo(Amigo amigo)
        {
            if (!ExecutarValidacao(new AmigoValidation(), amigo)) return;

            await _amigoRepository.Atualizar(amigo);
        }

        public async Task AtualizarJogo(Jogo jogo)
        {
            if (!ExecutarValidacao(new JogoValidation(), jogo)) return;

            await _jogoRepository.Atualizar(jogo);
        }

        public async Task Remover(Guid id)
        {
            var Amigo = await _amigoRepository.ObterAmigoPorEmprestimo(id);

            await _emprestimoRepository.Remover(id);

            if (Amigo != null)
            {
                await _amigoRepository.Remover(Amigo.Id);
            }
        }

        public void Dispose()
        {
            _emprestimoRepository?.Dispose();
            _amigoRepository?.Dispose();
        }
    }
}
