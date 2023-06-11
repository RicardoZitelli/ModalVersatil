using ModaVersatilApplication.DTOs.Request;
using ModaVersatilApplication.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModaVersatilApplication.Interfaces
{
    public interface ITipoProdutoAppService
    {
        Task AdicionarAsync(TipoProdutoDTORequest tipoProduto);
        Task AlterarAsync(TipoProdutoDTORequest tipoProduto);
        Task ExcluirAsync(int id);
        Task<TipoProdutoDTOResponse> ObterAsync(int id);
        Task<IEnumerable<TipoProdutoDTOResponse>> ListarAsync();
    }
}
