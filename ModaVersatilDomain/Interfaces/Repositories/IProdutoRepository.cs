using ModaVersatilDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModaVersatilDomain.Interfaces.Repositories
{
    public interface IProdutoRepository: IDisposable
    {
        Task AdicionarAsync(Produto produto);
        Task AlterarAsync(Produto produto);
        Task ExcluirAsync(int id);
        Task<Produto> ObterAsync(int id);
        Task<IEnumerable<Produto>> ListarAsync();
    }
}
