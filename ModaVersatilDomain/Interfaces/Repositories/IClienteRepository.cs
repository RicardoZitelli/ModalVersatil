using ModaVersatilDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModaVersatilDomain.Interfaces.Repositories
{
    public interface IClienteRepository
    {
        Task AdicionarAsync(Cliente cliente);
        Task AlterarAsync(Cliente cliente);
        Task ExcluirAsync(int id);
        Task<Cliente> ObterAsync(int id);
        Task<IEnumerable<Cliente>> ListarAsync();

    }
}
