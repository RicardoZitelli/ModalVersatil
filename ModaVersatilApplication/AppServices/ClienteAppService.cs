using AutoMapper;
using ModaVersatilApplication.DTOs.Request;
using ModaVersatilApplication.DTOs.Response;
using ModaVersatilApplication.Interfaces;
using ModaVersatilDomain.Interfaces.Services;
using ModaVersatilDomain.Models;

namespace ModaVersatilApplication.AppServices
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IMapper _mapper;
        private readonly IClienteService _clienteService;

        public ClienteAppService(IMapper mapper, IClienteService clienteService)
        {
            _mapper = mapper;
            _clienteService = clienteService;
        }

        public async Task AdicionarAsync(ClienteDTORequest cliente)
        {
            try
            {
                var model = _mapper.Map<Cliente>(cliente);

                await _clienteService.AdicionarAsync(model);
            }
            catch (Exception)
            {

                throw;
            }            
        }

        public async Task AlterarAsync(ClienteDTORequest cliente)
        {
            var model = _mapper.Map<Cliente>(cliente);

            await _clienteService.AlterarAsync(model);
        }

        public async Task ExcluirAsync(int id)
        {
            await _clienteService.ExcluirAsync(id); 
        }

        public async Task<IEnumerable<ClienteDTOResponse>> ListarAsync()
        {
            return _mapper.Map<IEnumerable<ClienteDTOResponse>>(await _clienteService.ListarAsync());
        }

        public async Task<ClienteDTOResponse> ObterAsync(int id)
        {
            return _mapper.Map<ClienteDTOResponse>(await _clienteService.ObterAsync(id));
        }
    }
}
