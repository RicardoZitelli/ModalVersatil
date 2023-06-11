using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModaVersatilApplication.AppServices;
using ModaVersatilApplication.AutoMapper;
using ModaVersatilApplication.Interfaces;
using ModaVersatilDomain.Interfaces.Repositories;
using ModaVersatilDomain.Interfaces.Services;
using ModaVersatilDomain.Interfaces.UnitOfWork;
using ModaVersatilDomain.Services;
using ModaVesatilInfrastructure;
using ModaVesatilInfrastructure.Repositories;
using ModaVesatilInfrastructure.Uow;
using System.Data;

namespace ModaVersatilIoC
{
    public class InjetorDependencia
    {
        private readonly IServiceCollection _services;
        private readonly IConfiguration _configuration;

        public InjetorDependencia(IServiceCollection services, IConfiguration configuration)
        {
            _services = services;
            _configuration = configuration;

            ConfigurarDependencias();
        }

        public void ConfigurarDependencias()
        {
            _services.AddSingleton(x => _configuration);
            _services.AddScoped<IDbConnection>(db => new SqlConnection(new DbConnectionFactory(_configuration).ObterStringDeConexao()));

            ConfigurarMapper();
            
            ConfigurarAppService();
            ConfigurarServices();
            ConfigurarRepositories();
        }

        private void ConfigurarMapper()
        {
            _services.AddSingleton(new MapperConfiguration(configure =>
            {
                configure.AddProfile(new DtoToModelMappingProfile());
                configure.AddProfile(new ModelToDtoMappingProfile());
            }).CreateMapper());
        }

        public void ConfigurarAppService()
        {
            _services.AddScoped<ITipoProdutoAppService, TipoProdutoAppService>();
        }

        private void ConfigurarServices()
        {
            _services.AddScoped<ITipoProdutoService, TipoProdutoService>();
        }

        public void ConfigurarRepositories()
        {
            _services.AddScoped<ITipoProdutoRepository, TipoProdutoRepository>();
            _services.AddScoped<IProdutoRepository, ProdutoRepository>();
            _services.AddScoped<IClienteRepository, ClienteRepository>();
            _services.AddScoped<ICarrinhoRepository, CarrinhoRepository>();
            _services.AddScoped<IVendaRepository, VendaRepository>();
            
            _services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

    }  
}