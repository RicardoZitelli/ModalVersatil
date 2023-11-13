using ModaVersatilDomain.Interfaces.Repositories;

namespace ModaVersatilDomain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        ITipoProdutoRepository TipoProdutoRepository { get; }
        IProdutoRepository ProdutoRepository { get; }
        IClienteRepository ClienteRepository { get; }
        ICarrinhoRepository CarrinhoRepository { get; }
        IVendaRepository VendaRepository { get; }

    }
}
