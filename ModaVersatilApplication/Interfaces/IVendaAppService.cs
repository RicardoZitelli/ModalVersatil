using ModaVersatilApplication.DTOs.Request;
using ModaVersatilApplication.DTOs.Response;

namespace ModaVersatilApplication.Interfaces
{
    public interface IVendaAppService
    {
        Task AdicionarAsync(VendaDTORequest venda);
        Task AlterarAsync(VendaDTORequest venda);
        Task<VendaDTORequest> ObterAsync(int id);
        Task<IEnumerable<VendaDTOResponse>> ListarAsync();
        Task<IEnumerable<VendaDTOResponse>> ListarPorClienteAsync(int clienteId);
        Task<IEnumerable<VendaDTOResponse>> ListarPorPeriodoAsync(DateTime dataInicio, DateTime dataFim);
    }
}
