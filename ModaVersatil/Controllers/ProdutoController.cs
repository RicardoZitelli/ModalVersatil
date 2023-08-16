using Microsoft.AspNetCore.Mvc;
using ModaVersatilApplication.DTOs.Request;
using ModaVersatilApplication.DTOs.Response;
using ModaVersatilApplication.Interfaces;

namespace ModaVersatil.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly ILogger<ProdutoController> _logger;
        private readonly IProdutoAppService _produtoAppService;

        public ProdutoController(ILogger<ProdutoController> logger, IProdutoAppService produtoAppService)
        {
            _logger = logger;
            _produtoAppService = produtoAppService;
        }

        [HttpPost]
        [Route("AdicionarProdutoAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task AdicionarProdutoAsync([FromBody] ProdutoDTORequest tipoProdutoDTORequest)
        {
            await _produtoAppService.AdicionarAsync(tipoProdutoDTORequest);

            _logger.LogInformation("Produto adicionado.");
        }

        [HttpPut]
        [Route("AlterarProdutoAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task AlterarProdutoAsync([FromBody] ProdutoDTORequest tipoProdutoDTORequest)
        {
            await _produtoAppService.AlterarAsync(tipoProdutoDTORequest);

            _logger.LogInformation("Produto alterado.");
        }

        [HttpDelete]
        [Route("ExcluirProdutoAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task ExcluirProdutoAsync([FromHeader] int id)
        {
            await _produtoAppService.ExcluirAsync(id);

            _logger.LogInformation("Produto excluído.");
        }

        [HttpGet]
        [Route("ObterProdutoAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ProdutoDTOResponse> ObterProdutoAsync([FromHeader] int id)
        {
            return await _produtoAppService.ObterAsync(id);            
        }

        [HttpGet]
        [Route("ListarProdutoAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IEnumerable<ProdutoDTOResponse>> ListarProdutoAsync()
        {
            return await _produtoAppService.ListarAsync();
        }

    }
}
