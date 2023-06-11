using ModaVersatilDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModaVersatilDomain.Interfaces.Repositories
{
    public interface IVendaRepository
    {
        Task AdicionarAsync(Venda venda);
        Task AlterarAsync(Venda venda);
        Task ExcluirAsync(int id);
        Task<Venda> ObterAsync(int id);
        Task<IEnumerable<Venda>> ListarAsync();
        
        Task<IEnumerable<Venda>> ListarPorClienteAsync(int clienteId);
        Task<IEnumerable<Venda>> ListarPorPeriodoAsync(DateTime dataInicio, DateTime dataFim);
    }
}
