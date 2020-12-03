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

        public EmprestimoService(IEmprestimoRepository EmprestimoRepository,
                                 IAmigoRepository AmigoRepository,
                                 INotificador notificador) : base(notificador)
        {
            _EmprestimoRepository = EmprestimoRepository;
            _AmigoRepository = AmigoRepository;
        }

        public async Task Adicionar(Emprestimo emprestimo)
        {
            if (!ExecutarValidacao(new EmprestimoValidation(), emprestimo)
                || !ExecutarValidacao(new AmigoValidation(), emprestimo.Amigo)) return;

            if (_EmprestimoRepository.Buscar(f => f.Amigo.Nome == emprestimo.Amigo.Nome).Result.Any())
            {
                Notificar("Já existe um Emprestimo com este documento infomado.");
                return;
            }

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

        public async Task AtualizarAmigo(Amigo Amigo)
        {
            if (!ExecutarValidacao(new AmigoValidation(), Amigo)) return;

            await _AmigoRepository.Atualizar(Amigo);
        }

        public async Task Remover(Guid id)
        {
            if (_EmprestimoRepository.ObterEmprestimoJogosAmigo(id).Result.Jogo != null)
            {
                Notificar("O Emprestimo possui jogos cadastrados!");
                return;
            }

            var Amigo = await _AmigoRepository.ObterAmigoPorEmprestimo(id);

            if (Amigo != null)
            {
                await _AmigoRepository.Remover(Amigo.Id);
            }

            await _EmprestimoRepository.Remover(id);
        }

        public void Dispose()
        {
            _EmprestimoRepository?.Dispose();
            _AmigoRepository?.Dispose();
        }
    }
}
