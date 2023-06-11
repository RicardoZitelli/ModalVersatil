using AutoMapper;
using ModaVersatilApplication.DTOs.Request;
using ModaVersatilApplication.DTOs.Response;
using ModaVersatilApplication.Interfaces;
using ModaVersatilDomain.Interfaces.Services;
using ModaVersatilDomain.Models;

namespace ModaVersatilApplication.AppServices
{
    public class VendaAppService : IVendaAppService
    {

        private readonly IMapper _mapper;
        private readonly IVendaService _vendaService;

        public VendaAppService(IMapper mapper, IVendaService vendaService)
        {
            _mapper = mapper;
            _vendaService = vendaService;
        }

        public async Task AdicionarAsync(VendaDTORequest venda)
        {
            var model = _mapper.Map<Venda>(venda);

            await _vendaService.AdicionarAsync(model);
        }

        public async Task AlterarAsync(VendaDTORequest venda)
        {
            var model = _mapper.Map<Venda>(venda);

            await _vendaService.AlterarAsync(model);
        }

        public async Task<IEnumerable<VendaDTOResponse>> ListarAsync()
        {
            return _mapper.Map<IEnumerable<VendaDTOResponse>>(await _vendaService.ListarAsync());
        }

        public async Task<IEnumerable<VendaDTOResponse>> ListarPorClienteAsync(int clienteId)
        {
            return _mapper.Map<IEnumerable<VendaDTOResponse>>(await _vendaService.ListarPorClienteAsync(clienteId));
        }

        public async Task<IEnumerable<VendaDTOResponse>> ListarPorPeriodoAsync(DateTime dataInicio, DateTime dataFim)
        {
            return _mapper.Map<IEnumerable<VendaDTOResponse>>(await _vendaService.ListarPorPeriodoAsync(dataInicio, dataFim));
        }

        public async Task<VendaDTORequest> ObterAsync(int id)
        {
            return _mapper.Map<VendaDTORequest>(await _vendaService.ObterAsync(id));
        }
    }
}
