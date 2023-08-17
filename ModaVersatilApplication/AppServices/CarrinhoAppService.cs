using AutoMapper;
using ModaVersatilApplication.DTOs.Request;
using ModaVersatilApplication.DTOs.Response;
using ModaVersatilApplication.Interfaces;
using ModaVersatilDomain.Interfaces.Services;
using ModaVersatilDomain.Models;

namespace ModaVersatilApplication.AppServices
{
    public class CarrinhoAppService : ICarrinhoAppService
    {
        private readonly IMapper _mapper;
        private readonly ICarrinhoService _carrinhoService;

        public CarrinhoAppService(IMapper mapper, ICarrinhoService carrinhoService)
        {
            _mapper = mapper;
            _carrinhoService = carrinhoService;
        }

        public async Task AdicionarAsync(CarrinhoDTORequest carrinho)
        {
            var model = _mapper.Map<Carrinho>(carrinho);

            await _carrinhoService.AdicionarAsync(model);
        }

        public async Task AlterarAsync(CarrinhoDTORequest carrinho)
        {
            var model = _mapper.Map<Carrinho>(carrinho);

            await _carrinhoService.AlterarAsync(model);
        }

        public async Task ExcluirAsync(int clienteId)
        {
            await _carrinhoService.ExcluirAsync(clienteId);
        }

        public async Task ExcluirProdutoAsync(int clienteId, int produtoId)
        {
            await _carrinhoService.ExcluirProdutoAsync(clienteId, produtoId);
        }

        public async Task<IEnumerable<CarrinhoDTOResponse>> ListarAsync()
        {
            return _mapper.Map<IEnumerable<CarrinhoDTOResponse>>(await _carrinhoService.ListarAsync());
        }

        public async Task<CarrinhoDTOResponse> ObterAsync(int id)
        {
            return _mapper.Map<CarrinhoDTOResponse>(await _carrinhoService.ObterAsync(id));
        }

        public async Task<IEnumerable<CarrinhoDTOResponse>> ListarPorClienteAsync(int clienteId)
        {
            return _mapper.Map<IEnumerable<CarrinhoDTOResponse>>(await _carrinhoService.ListarPorClienteAsync(clienteId));
        }
    }
}
