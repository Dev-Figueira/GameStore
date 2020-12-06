using GameStore.Data.Repositories;
using GameStore.Domain.Interfaces;
using GameStore.Domain.Models;
using GameStore.Domain.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.WebApp.MVC.Services
{
    public class EmprestimoService : Service, IEmprestimoService
    {
        private readonly IEmprestimoRepository _EmprestimoRepository;
        private readonly IAmigoRepository _AmigoRepository;
        private readonly IJogoRepository _JogoRepository;

        public EmprestimoService(IEmprestimoRepository EmprestimoRepository,
                                 IAmigoRepository AmigoRepository,
                                 IJogoRepository JogoRepository,
                                 INotificador notificador) : base(notificador)
        {
            _EmprestimoRepository = EmprestimoRepository;
            _AmigoRepository = AmigoRepository;
            _JogoRepository = JogoRepository;
        }

        public async Task Adicionar(Emprestimo emprestimo)
        {
            if (!ExecutarValidacao(new EmprestimoValidation(), emprestimo)
                || !ExecutarValidacao(new AmigoValidation(), emprestimo.Amigo)) return;

            emprestimo.Jogo.Emprestado = true;
            await _JogoRepository.Atualizar(emprestimo.Jogo);

            if (emprestimo.Amigo.Id == Guid.Empty)
            {
                await _AmigoRepository.Adicionar(emprestimo.Amigo);
            }

            await _EmprestimoRepository.Adicionar(emprestimo);
        }

        public async Task Atualizar(Emprestimo emprestimo)
        {
            if (!ExecutarValidacao(new EmprestimoValidation(), emprestimo)) return;

            if (_EmprestimoRepository.Buscar(f => f.Amigo.Nome == emprestimo.Amigo.Nome && f.Id != emprestimo.Id).Result.Any())
            {
                Notificar("Já existe um Emprestimo com este documento infomado.");
                return;
            }

            await _EmprestimoRepository.Atualizar(emprestimo);
        }

        public async Task AtualizarAmigo(Amigo amigo)
        {
            if (!ExecutarValidacao(new AmigoValidation(), amigo)) return;

            await _AmigoRepository.Atualizar(amigo);
        }

        public async Task AtualizarJogo(Jogo jogo)
        {
            if (!ExecutarValidacao(new JogoValidation(), jogo)) return;

            await _JogoRepository.Atualizar(jogo);
        }

        public async Task Remover(Guid id)
        {
            var Amigo = await _AmigoRepository.ObterAmigoPorEmprestimo(id);

            await _EmprestimoRepository.Remover(id);

            if (Amigo != null)
            {
                await _AmigoRepository.Remover(Amigo.Id);
            }
        }

        public void Dispose()
        {
            _EmprestimoRepository?.Dispose();
            _AmigoRepository?.Dispose();
        }
    }
}
