using Microsoft.AspNetCore.Mvc;
using ModaVersatilApplication.DTOs.Request;
using ModaVersatilApplication.DTOs.Response;
using ModaVersatilApplication.Interfaces;

namespace ModaVersatil.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarrinhoController : ControllerBase
    {
        private readonly ILogger<ProdutoController> _logger;
        private readonly ICarrinhoAppService _carrinhoAppService;

        public CarrinhoController(ILogger<ProdutoController> logger, ICarrinhoAppService carrinhoAppService)
        {
            _logger = logger;
            _carrinhoAppService = carrinhoAppService;
        }

        [HttpPost]
        [Route("AdicionarProdutoCarrinhoAsync")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task AdicionarProdutoAsync([FromBody] CarrinhoDTORequest carrinhoDTORequest)
        {
            await _carrinhoAppService.AdicionarAsync(carrinhoDTORequest);

            _logger.LogInformation("Produto adicionado.");
        }

        [HttpDelete]
        [Route("ExcluirProdutoCarrinhoAsync/{clienteId}/{produtoId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task ExcluirProdutoCarrinhoAsync([FromRoute] int clienteId, int produtoId)
        {
            await _carrinhoAppService.ExcluirProdutoAsync(clienteId, produtoId);

            _logger.LogInformation("Produtos excluídos.");
        }

        [HttpGet]
        [Route("ListarProdutosCarrinhoAsync/{clienteId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IEnumerable<CarrinhoDTOResponse>> ListarProdutosPorClienteAsync([FromRoute] int clienteId)
        {
            return await _carrinhoAppService.ListarPorClienteAsync(clienteId);                        
        }
    }
}
