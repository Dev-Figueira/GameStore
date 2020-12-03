using GameStore.Data.Context;
using GameStore.Data.Repositories;
using GameStore.Domain;
using GameStore.Domain.Interfaces;
using GameStore.WebApp.MVC.Extensions;
using GameStore.WebApp.MVC.Services;
using GameStore.WebApp.MVC.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GameStore.WebApp.MVC.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<DbContext, GameStoreDbContex>();

            services.AddScoped<IJogoRepository, JogoRepository>();
            services.AddScoped<IEmprestimoRepository, EmprestimoRepository>();
            services.AddScoped<IAmigoRepository, AmigoRepository>();
            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IEmprestimoService, EmprestimoService>();
            services.AddScoped<IJogoService, JogoService>();

            services.AddHttpClient<IAutenticacaoService, AutenticacaoService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IUser, AspNetUser>();
            
        }
    }
}
