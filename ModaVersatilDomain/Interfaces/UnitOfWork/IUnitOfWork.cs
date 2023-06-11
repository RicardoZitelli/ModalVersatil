using ModaVersatilDomain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModaVersatilDomain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        ITipoProdutoRepository TipoProdutoRepository { get; }
        IProdutoRepository ProdutoRepository { get; }
        IClienteRepository ClienteRepository { get; }
        ICarrinhoRepository CarrinhoRepository { get; }
        IVendaRepository VendaRepository { get; }

        void Commit();
        void BeginTransaction();
        void Rollback();

    }
}
