using ModaVersatilDomain.Models;

namespace ModaVersatilDomain.Interfaces.Services
{
    public interface IVendaService
    {
        Task AdicionarAsync(Venda venda);
        Task AlterarAsync(Venda venda);        
        Task<Venda> ObterAsync(int id);
        Task<IEnumerable<Venda>> ListarAsync();
        Task<IEnumerable<Venda>> ListarPorClienteAsync(int clienteId);
        Task<IEnumerable<Venda>> ListarPorPeriodoAsync(DateTime dataInicio, DateTime dataFim);
    }
}
