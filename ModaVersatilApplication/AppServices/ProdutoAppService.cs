using AutoMapper;
using ModaVersatilApplication.DTOs.Request;
using ModaVersatilApplication.DTOs.Response;
using ModaVersatilApplication.Interfaces;
using ModaVersatilDomain.Interfaces.Services;
using ModaVersatilDomain.Models;

namespace ModaVersatilApplication.AppServices
{
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IMapper _mapper;
        private readonly IProdutoService _produtoService;

        public ProdutoAppService(IMapper mapper, IProdutoService produtoService)
        {
            _mapper = mapper;
            _produtoService = produtoService;
        }

        public async Task AdicionarAsync(ProdutoDTORequest produto)
        {
            var model = _mapper.Map<Produto>(produto);

            await _produtoService.AdicionarAsync(model);
        }

        public async Task AlterarAsync(ProdutoDTORequest produto)
        {
            var model = _mapper.Map<Produto>(produto);

            await _produtoService.AlterarAsync(model);
        }

        public async Task ExcluirAsync(int id)
        {
            await _produtoService.ExcluirAsync(id);
        }

        public async Task<IEnumerable<ProdutoDTOResponse>> ListarAsync()
        {
            return _mapper.Map<IEnumerable<ProdutoDTOResponse>>(await _produtoService.ListarAsync());
        }

        public async Task<ProdutoDTOResponse> ObterAsync(int id)
        {
            return _mapper.Map<ProdutoDTOResponse>(await _produtoService.ObterAsync(id));            
        }
    }
}
