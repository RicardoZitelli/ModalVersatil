using ModaVersatilDomain.Models;

namespace ModaVersatilDomain.Interfaces.Services
{
    public interface ICarrinhoService
    {
        Task AdicionarAsync(Carrinho carrinho);
        Task AlterarAsync(Carrinho carrinho);
        Task ExcluirAsync(int id);
        Task<Carrinho> ObterAsync(int id);
        Task<IEnumerable<Carrinho>> ListarAsync();
    }
}
