using ModaVersatilDomain.Models;

namespace ModaVersatilDomain.Interfaces.Services
{
    public interface IClienteService
    {
        Task AdicionarAsync(Cliente cliente);
        Task AlterarAsync(Cliente cliente);
        Task ExcluirAsync(int id);
        Task<Cliente> ObterAsync(int id);
        Task<IEnumerable<Cliente>> ListarAsync();
    }
}
