using AutoMapper;
using GameStore.Domain.Interfaces;
using GameStore.Domain.Models;
using GameStore.WebApp.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.WebApp.MVC.Controllers
{
    [Authorize]
    public class JogosController : BaseController
    {
        private readonly IJogoRepository _jogoRepository;
        private readonly IJogoService _jogoService;
        private readonly IMapper _mapper;

        public JogosController(IJogoRepository jogoRepository,
                                  IEmprestimoRepository emprestimoRepository,
                                  IMapper mapper,
                                  IJogoService jogoService,
                                  INotificador notificador)
        {
            _jogoRepository = jogoRepository;
            _mapper = mapper;
            _jogoService = jogoService;
        }

        [AllowAnonymous]
        [Route("lista-de-Jogos")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<JogoViewModel>>(await _jogoRepository.ObterTodos()));
        }

        [Route("dados-do-Jogo/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var JogoViewModel = await ObterJogo(id);

            if (JogoViewModel == null)
            {
                return NotFound();
            }

            return View(JogoViewModel);
        }

        [Route("novo-Jogo")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [Route("novo-Jogo")]
        [HttpPost]
        public async Task<IActionResult> Create(JogoViewModel jogoViewModel)
        {
            jogoViewModel.Emprestado = false;

            if (!ModelState.IsValid) return View(jogoViewModel);

            await _jogoService.Adicionar(_mapper.Map<Jogo>(jogoViewModel));

            if (!OperacaoValida()) return View(jogoViewModel);

            return RedirectToAction("Index");
        }

        [Route("editar-Jogo/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var jogoViewModel = await ObterJogo(id);

            if (jogoViewModel == null)
            {
                return NotFound();
            }

            return View(jogoViewModel);
        }

        [Route("editar-Jogo/{id:guid}")]
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, JogoViewModel jogoViewModel)
        {
            if (id != jogoViewModel.Id) return NotFound();

            var jogoAtualizacao = await ObterJogo(id);
            if (!ModelState.IsValid) return View(jogoViewModel);

            jogoAtualizacao.Nome = jogoViewModel.Nome;
            jogoAtualizacao.Genero = jogoViewModel.Genero;

            await _jogoService.Atualizar(_mapper.Map<Jogo>(jogoAtualizacao));

            if (!OperacaoValida()) return View(jogoViewModel);

            return RedirectToAction("Index");
        }

        [Route("excluir-Jogo/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var jogo = await ObterJogo(id);

            if (jogo == null)
            {
                return NotFound();
            }

            return View(jogo);
        }

        [Route("excluir-Jogo/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var jogo = await ObterJogo(id);

            if (jogo == null)
            {
                return NotFound();
            }

            await _jogoService.Remover(id);

            if (!OperacaoValida()) return View(jogo);

            TempData["Sucesso"] = "Jogo excluido com sucesso!";

            return RedirectToAction("Index");
        }

        private async Task<JogoViewModel> ObterJogo(Guid id)
        {
            var jogo = _mapper.Map<JogoViewModel>(await _jogoRepository.ObterPorId(id));
            return jogo;
        }
    }
}
