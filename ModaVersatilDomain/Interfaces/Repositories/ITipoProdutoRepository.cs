using ModaVersatilDomain.Models;

namespace ModaVersatilDomain.Interfaces.Repositories
{
    public interface ITipoProdutoRepository : IDisposable
    {
        Task AdicionarAsync(TipoProduto tipoProduto);
        Task AlterarAsync(TipoProduto tipoProduto);
        Task ExcluirAsync(int id);
        Task<TipoProduto> ObterAsync(int id);
        Task<IEnumerable<TipoProduto>> ListarAsync();

    }
}
