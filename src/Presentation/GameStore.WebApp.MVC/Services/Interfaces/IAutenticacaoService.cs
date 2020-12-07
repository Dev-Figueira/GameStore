using GameStore.WebApp.MVC.Models;
using System.Threading.Tasks;

namespace GameStore.WebApp.MVC.Services.Interfaces
{
    public interface IAutenticacaoService
    {
        Task<UsuarioRespostaLogin> Login(UsuarioLogin usuarioLogin);

        Task<UsuarioRespostaLogin> Registro(UsuarioViewModel usuarioRegistro);
    }
}
