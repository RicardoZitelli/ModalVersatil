using ModaVersatilDomain.Models;

namespace ModaVersatilDomain.Interfaces.Repositories
{
    public interface IVendaRepository
    {
        Task AdicionarAsync(Venda venda);
        Task AlterarAsync(Venda venda);        
        Task<Venda> ObterAsync(int id);
        Task<IEnumerable<Venda>> ListarAsync();
        
        Task<IEnumerable<Venda>> ListarPorClienteAsync(int clienteId);
        Task<IEnumerable<Venda>> ListarPorPeriodoAsync(DateTime dataInicio, DateTime dataFim);
    }
}
