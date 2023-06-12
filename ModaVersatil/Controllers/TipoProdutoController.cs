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

        [HttpPost("/AdicionarTipoProdutoAsync")]
        public async Task AdicionarTipoProdutoAsync([FromBody] TipoProdutoDTORequest tipoProdutoDTORequest)
        {
            await _tipoProdutoAppService.AdicionarAsync(tipoProdutoDTORequest);
            
            _logger.LogInformation("Categoria Tipo de Produto adicionado.");
        }

        [HttpPut("/AlterarTipoProdutoAsync")]
        public async Task AlterarTipoProdutoAsync([FromBody] TipoProdutoDTORequest tipoProdutoDTORequest)
        {
            await _tipoProdutoAppService.AlterarAsync(tipoProdutoDTORequest);

            _logger.LogInformation($"Categoria Tipo de Produto {tipoProdutoDTORequest.Id} alterado.");
        }

        [HttpDelete("/ExcluirTipoProdutoAsync")]
        public async Task ExcluirTipoProdutoAsync([FromHeader] int id)
        {
            await _tipoProdutoAppService.ExcluirAsync(id);

            _logger.LogInformation($"Categoria Tipo de Produto {id} excluído.");
        }

        [HttpGet("/ObterTipoProdutoAsync")]
        public async Task<TipoProdutoDTOResponse> ObterTipoProdutoAsync([FromHeader] int id)
        {
            return await _tipoProdutoAppService.ObterAsync(id);
        }

        [HttpGet("/ListarTipoProdutoAsync")]
        public async Task<IEnumerable<TipoProdutoDTOResponse>> ListarTipoProdutoAsync()
        {
            return await _tipoProdutoAppService.ListarAsync();
        }
    }
}
