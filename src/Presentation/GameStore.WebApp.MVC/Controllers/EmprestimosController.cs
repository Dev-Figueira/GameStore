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
    public class EmprestimosController : BaseController
    {
        private readonly IEmprestimoService _emprestimoService;
        private readonly IEmprestimoRepository _emprestimoRepository;
        private readonly IJogoRepository _jogoRepository;
        private readonly IAmigoRepository _amigoRepository;
        private readonly IMapper _mapper;

        public EmprestimosController(IEmprestimoService emprestimoService, 
                                    IEmprestimoRepository emprestimoRepository,
                                    IJogoRepository jogoRepository,
                                    IAmigoRepository amigoRepository,
                                    IMapper mapper)
        {
            _emprestimoService = emprestimoService;
            _emprestimoRepository = emprestimoRepository;
            _jogoRepository = jogoRepository;
            _amigoRepository = amigoRepository;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<EmprestimoViewModel>>(await _emprestimoRepository.ObterEmprestimoJogosAmigo()));
        }
        
        [Route("dados-do-emprestimo/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var emprestimoViewModel = await ObterEmprestimoJogoAmigo(id);

            if (emprestimoViewModel == null)
            {
                return NotFound();
            }

            return View(emprestimoViewModel);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.ComboAmigo = _mapper.Map<IEnumerable<AmigoViewModel>>(await _amigoRepository.ObterTodos());
            ViewBag.ComboJogos = _mapper.Map<IEnumerable<JogoViewModel>>(await _jogoRepository.ObterTodosNaoEmprestado());

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmprestimoViewModel emprestimoViewModel)
        {
            emprestimoViewModel = await PopularJogos(emprestimoViewModel);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _emprestimoService.Adicionar(_mapper.Map<Emprestimo>(emprestimoViewModel));

            return RedirectToAction("Index");
        }

        [Route("editar-emprestimo/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var emprestimoViewModel = await ObterEmprestimoJogoAmigo(id);

            if (emprestimoViewModel == null)
            {
                return NotFound();
            }

            return View(emprestimoViewModel);
        }

        [Route("editar-emprestimo/{id:guid}")]
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, EmprestimoViewModel emprestimoViewModel)
        {
            if (id != emprestimoViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(emprestimoViewModel);

            var emprestimo = _mapper.Map<Emprestimo>(emprestimoViewModel);
            await _emprestimoService.Atualizar(emprestimo);

            if (!OperacaoValida()) return View(await ObterEmprestimoJogoAmigo(id));

            return RedirectToAction("Index");
        }

        [Route("excluir-emprestimo/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var emprestimoViewModel = await ObterEmprestimoJogoAmigo(id);

            if (emprestimoViewModel == null)
            {
                return NotFound();
            }

            return View(emprestimoViewModel);
        }

        [Route("excluir-emprestimo/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var emprestimo = await ObterEmprestimoJogoAmigo(id);

            if (emprestimo == null) return NotFound();

            await _emprestimoService.Remover(id);

            if (!OperacaoValida()) return View(emprestimo);

            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [Route("obter-amigo-emprestimo/{id:guid}")]
        public async Task<IActionResult> ObterAmigo(Guid id)
        {
            var emprestimo = await ObterEmprestimoAmigo(id);

            if (emprestimo == null)
            {
                return NotFound();
            }

            return PartialView("_DetalhesAmigo", emprestimo);
        }

        [AllowAnonymous]
        [Route("obter-jogo-emprestimo/{id:guid}")]
        public async Task<IActionResult> ObterJogo(Guid id)
        {
            var emprestimo = await ObterEmprestimoJogoAmigo(id);

            if (emprestimo == null)
            {
                return NotFound();
            }

            return PartialView("_DetalhesJogo", emprestimo);
        }

        [Route("atualizar-amigo-emprestimo/{id:guid}")]
        public async Task<IActionResult> AtualizarAmigo(Guid id)
        {
            var emprestimo = await ObterEmprestimoAmigo(id);

            if (emprestimo == null)
            {
                return NotFound();
            }

            return PartialView("_AtualizarAmigo", new EmprestimoViewModel { Amigo = emprestimo.Amigo });
        }

        [Route("atualizar-amigo-emprestimo/{id:guid}")]
        [HttpPost]
        public async Task<IActionResult> AtualizarAmigo(EmprestimoViewModel emprestimoViewModel)
        {
            ModelState.Remove("Nome");

            if (!ModelState.IsValid) return PartialView("_AtualizarAmigo", emprestimoViewModel);

            await _emprestimoService.AtualizarAmigo(_mapper.Map<Amigo>(emprestimoViewModel.Amigo));

            if (!OperacaoValida()) return PartialView("_AtualizarAmigo", emprestimoViewModel);

            var url = Url.Action("ObterAmigo", "Emprestimos", new { id = emprestimoViewModel.Id });
            return Json(new { success = true, url });
        }

        [Route("atualizar-jogo-emprestimo/{id:guid}")]
        public async Task<IActionResult> AtualizarJogo(Guid id)
        {
            var emprestimo = await ObterEmprestimoJogoAmigo(id);

            if (emprestimo == null)
            {
                return NotFound();
            }

            return PartialView("_AtualizarJogo", new EmprestimoViewModel { Jogo = emprestimo.Jogo});
        }

        [Route("atualizar-jogo-emprestimo/{id:guid}")]
        [HttpPost]
        public async Task<IActionResult> AtualizarJogo(EmprestimoViewModel emprestimoViewModel)
        {
            ModelState.Remove("Nome");

            if (!ModelState.IsValid) return PartialView("_AtualizarJogo", emprestimoViewModel);

            await _emprestimoService.AtualizarJogo(_mapper.Map<Jogo>(emprestimoViewModel.Jogo));

            if (!OperacaoValida()) return PartialView("_AtualizarJogo", emprestimoViewModel);

            var url = Url.Action("ObterJogo", "Emprestimos", new { id = emprestimoViewModel.Id });
            return Json(new { success = true, url });
        }

        private async Task<EmprestimoViewModel> ObterEmprestimoAmigo(Guid id)
        {
            return _mapper.Map<EmprestimoViewModel>(await _emprestimoRepository.ObterEmprestimoAmigo(id));
        }
        private async Task<EmprestimoViewModel> ObterEmprestimoJogoAmigo(Guid id)
        {
            return _mapper.Map<EmprestimoViewModel>(await _emprestimoRepository.ObterEmprestimoJogosAmigo(id));
        }

        private async Task<EmprestimoViewModel> PopularJogos(EmprestimoViewModel emprestimoViewModel)
        {
            emprestimoViewModel.Jogo = _mapper.Map<JogoViewModel>(await _jogoRepository.ObterPorId(emprestimoViewModel.Jogo.Id));
            return emprestimoViewModel;
        }
    }
}

