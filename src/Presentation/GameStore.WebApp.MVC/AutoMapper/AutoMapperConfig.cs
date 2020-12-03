using AutoMapper;
using GameStore.Domain.Models;
using GameStore.WebApp.MVC.Models;

namespace GameStore.WebApp.MVC.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Emprestimo, EmprestimoViewModel>().ReverseMap();
            CreateMap<Amigo, AmigoViewModel>().ReverseMap();
            CreateMap<Jogo, JogoViewModel>().ReverseMap();
        }
    }
}
