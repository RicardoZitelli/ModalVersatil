using ModaVersatilApplication.DTOs.Request;
using ModaVersatilApplication.DTOs.Response;

namespace ModaVersatilApplication.Interfaces
{
    public interface IProdutoAppService
    {
        Task AdicionarAsync(ProdutoDTORequest produto);
        Task AlterarAsync(ProdutoDTORequest produto);
        Task ExcluirAsync(int id);
        Task<ProdutoDTOResponse> ObterAsync(int id);
        Task<IEnumerable<ProdutoDTOResponse>> ListarAsync();
    }
}
