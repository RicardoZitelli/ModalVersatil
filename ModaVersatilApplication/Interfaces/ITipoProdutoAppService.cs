using ModaVersatilApplication.DTOs.Request;
using ModaVersatilApplication.DTOs.Response;

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
