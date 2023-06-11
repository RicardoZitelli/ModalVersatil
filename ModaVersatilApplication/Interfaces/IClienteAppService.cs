using ModaVersatilApplication.DTOs.Request;
using ModaVersatilApplication.DTOs.Response;

namespace ModaVersatilApplication.Interfaces
{
    public interface IClienteAppService
    {
        Task AdicionarAsync(ClienteDTORequest cliente);
        Task AlterarAsync(ClienteDTORequest cliente);
        Task ExcluirAsync(int id);
        Task<ClienteDTOResponse> ObterAsync(int id);
        Task<IEnumerable<ClienteDTOResponse>> ListarAsync();
    }
}
