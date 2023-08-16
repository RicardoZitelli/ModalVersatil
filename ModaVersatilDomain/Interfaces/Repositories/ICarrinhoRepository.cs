using ModaVersatilDomain.Models;

namespace ModaVersatilDomain.Interfaces.Repositories
{
    public interface ICarrinhoRepository
    {
        Task AdicionarAsync(Carrinho carrinho);
        Task AlterarAsync(Carrinho carrinho);
        Task ExcluirAsync(int id);        
        Task ExcluirProdutoAsync(int clienteId, int produtoId);
        Task<Carrinho> ObterAsync(int id);
        Task<IEnumerable<Carrinho>> ListarAsync();
        Task<IEnumerable<Carrinho>> ListarPorClienteAsync(int clienteId);
    }
}
