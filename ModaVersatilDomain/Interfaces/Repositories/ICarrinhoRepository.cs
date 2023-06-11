using ModaVersatilDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModaVersatilDomain.Interfaces.Repositories
{
    public interface ICarrinhoRepository
    {
        Task AdicionarAsync(Carrinho carrinho);
        Task AlterarAsync(Carrinho carrinho);
        Task ExcluirAsync(int id);
        Task<Carrinho> ObterAsync(int id);
        Task<IEnumerable<Carrinho>> ListarAsync();

    }
}
