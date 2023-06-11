using Microsoft.AspNetCore.Mvc;
using ModaVersatilApplication.DTOs.Request;
using ModaVersatilApplication.DTOs.Response;
using ModaVersatilApplication.Interfaces;

namespace ModaVersatil.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TipoProdutoController : ControllerBase
    {
        private readonly ILogger<TipoProdutoController> _logger;
        private readonly ITipoProdutoAppService _tipoProdutoAppService;
        public TipoProdutoController(ILogger<TipoProdutoController> logger, ITipoProdutoAppService tipoProdutoAppService)
        {
            _logger = logger;
            _tipoProdutoAppService = tipoProdutoAppService;
        }

        [HttpPost("/AdicionarTipoProduto")]
        public async Task AdicionarTipoProduto([FromBody] TipoProdutoDTORequest tipoProdutoDTORequest)
        {
            await _tipoProdutoAppService.AdicionarAsync(tipoProdutoDTORequest);
            
            _logger.LogInformation("Categoria Tipo de Produto adicionado.");
        }

        [HttpPut("/AlterarTipoProduto")]
        public async Task AlterarTipoProduto([FromBody] TipoProdutoDTORequest tipoProdutoDTORequest)
        {
            await _tipoProdutoAppService.AlterarAsync(tipoProdutoDTORequest);

            _logger.LogInformation($"Categoria Tipo de Produto {tipoProdutoDTORequest.Id} alterado.");
        }

        [HttpDelete("/ExcluirTipoProduto")]
        public async Task ExcluirTipoProduto([FromBody] int id)
        {
            await _tipoProdutoAppService.ExcluirAsync(id);

            _logger.LogInformation($"Categoria Tipo de Produto {id} excluído.");
        }

        [HttpPost("/ObterTipoProduto")]
        public async Task<TipoProdutoDTOResponse> ObterTipoProduto([FromBody] int id)
        {
            return await _tipoProdutoAppService.ObterAsync(id);
        }

        [HttpGet("/ListarTipoProduto")]
        public async Task<IEnumerable<TipoProdutoDTOResponse>> ListarTipoProduto()
        {
            return await _tipoProdutoAppService.ListarAsync();
        }
    }
}
