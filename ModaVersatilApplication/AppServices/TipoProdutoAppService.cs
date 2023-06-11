using AutoMapper;
using ModaVersatilApplication.DTOs.Request;
using ModaVersatilApplication.DTOs.Response;
using ModaVersatilApplication.Interfaces;
using ModaVersatilDomain.Interfaces.Services;
using ModaVersatilDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModaVersatilApplication.AppServices
{
    public class TipoProdutoAppService : ITipoProdutoAppService
    {
        private readonly IMapper _mapper;
        private readonly ITipoProdutoService _tipoProdutoService;

        public TipoProdutoAppService(IMapper mapper, ITipoProdutoService tipoProdutoService)
        {
            _mapper = mapper;
            _tipoProdutoService = tipoProdutoService;
        }

        public async Task AdicionarAsync(TipoProdutoDTORequest tipoProduto)
        {
            var model = _mapper.Map<TipoProduto>(tipoProduto);

            await _tipoProdutoService.AdicionarAsync(model);
        }

        public async Task AlterarAsync(TipoProdutoDTORequest tipoProduto)
        {
            var model = _mapper.Map<TipoProduto>(tipoProduto);

            await _tipoProdutoService.AlterarAsync(model);
        }

        public async Task ExcluirAsync(int id)
        {
            await _tipoProdutoService.ExcluirAsync(id);
        }

        public async Task<IEnumerable<TipoProdutoDTOResponse>> ListarAsync()
        {
            var dtos = _mapper.Map<IEnumerable<TipoProdutoDTOResponse>>(await _tipoProdutoService.ListarAsync());
                        
            return dtos;
        }

        public async Task<TipoProdutoDTOResponse> ObterAsync(int id)
        {
            var dtos = _mapper.Map<TipoProdutoDTOResponse>(await _tipoProdutoService.ObterAsync(id));

            return dtos;
        }
    }
}
