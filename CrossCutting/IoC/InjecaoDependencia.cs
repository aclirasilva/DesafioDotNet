using Application;
using Application.Interface;
using Domain.Interface;
using Infraestructure.Conexao;
using Infraestructure.Interface;
using Microsoft.Extensions.DependencyInjection;
using Repository;

namespace CrossCutting.IoC
{
    public static class InjecaoDependencia
    {
        public static IServiceCollection AddInject(this IServiceCollection service)
        {
            service.AddScoped<IDBConexao, DBConexao>();
            service.AddTransient<IProdutoServico, ProdutoServico>();
            service.AddTransient<IProdutoRepositorio, ProdutoRepositorio>();
            return service;
        }
    }
}