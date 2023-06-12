using Microsoft.AspNetCore.Mvc;
using ModaVersatilApplication.DTOs.Request;
using ModaVersatilApplication.DTOs.Response;
using ModaVersatilApplication.Interfaces;

namespace ModaVersatil.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : Controller
    {
        private readonly ILogger<ProdutoController> _logger;
        private readonly IProdutoAppService _produtoAppService;

        public ProdutoController(ILogger<ProdutoController> logger, IProdutoAppService produtoAppService)
        {
            _logger = logger;
            _produtoAppService = produtoAppService;
        }

        [HttpPost("/AdicionarProdutoAsync")]
        public async Task AdicionarProdutoAsync([FromBody] ProdutoDTORequest tipoProdutoDTORequest)
        {
            await _produtoAppService.AdicionarAsync(tipoProdutoDTORequest);

            _logger.LogInformation("Produto adicionado.");
        }

        [HttpPut("/AlterarProdutoAsync")]
        public async Task AlterarProdutoAsync([FromBody] ProdutoDTORequest tipoProdutoDTORequest)
        {
            await _produtoAppService.AlterarAsync(tipoProdutoDTORequest);

            _logger.LogInformation("Produto alterado.");
        }

        [HttpDelete("/ExcluirProdutoAsync")]
        public async Task ExcluirProdutoAsync([FromHeader] int id)
        {
            await _produtoAppService.ExcluirAsync(id);

            _logger.LogInformation("Produto excluído.");
        }

        [HttpGet("/ObterProdutoAsync")]
        public async Task<ProdutoDTOResponse> ObterProdutoAsync([FromHeader] int id)
        {
            return await _produtoAppService.ObterAsync(id);            
        }

        [HttpGet("/ListarProdutoAsync")]
        public async Task<IEnumerable<ProdutoDTOResponse>> ListarProdutoAsync()
        {
            return await _produtoAppService.ListarAsync();
        }

    }
}
