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

        [HttpPost("/AdicionarProduto")]
        public async Task AdicionarProduto([FromBody] ProdutoDTORequest tipoProdutoDTORequest)
        {
            await _produtoAppService.AdicionarAsync(tipoProdutoDTORequest);

            _logger.LogInformation("Produto adicionado.");
        }

        [HttpPut("/AlterarProduto")]
        public async Task AlterarProduto([FromBody] ProdutoDTORequest tipoProdutoDTORequest)
        {
            await _produtoAppService.AlterarAsync(tipoProdutoDTORequest);

            _logger.LogInformation("Produto alterado.");
        }

        [HttpDelete("/ExcluirProduto")]
        public async Task ExcluirProduto([FromHeader] int id)
        {
            await _produtoAppService.ExcluirAsync(id);

            _logger.LogInformation("Produto excluído.");
        }

        [HttpGet("/ObterProduto")]
        public async Task<ProdutoDTOResponse> ObterProduto([FromHeader] int id)
        {
            return await _produtoAppService.ObterAsync(id);            
        }

        [HttpGet("/ListarProduto")]
        public async Task<IEnumerable<ProdutoDTOResponse>> ListarProduto()
        {
            return await _produtoAppService.ListarAsync();
        }

    }
}
