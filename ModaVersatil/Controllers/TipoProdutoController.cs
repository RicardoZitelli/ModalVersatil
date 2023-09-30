using HashidsNet;
using Microsoft.AspNetCore.Mvc;
using ModaVersatilApplication.DTOs.Request;
using ModaVersatilApplication.DTOs.Response;
using ModaVersatilApplication.Interfaces;

namespace ModaVersatil.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TipoProdutoController : ControllerBase
    {
        private readonly ILogger<TipoProdutoController> _logger;
        private readonly ITipoProdutoAppService _tipoProdutoAppService;
        public TipoProdutoController(ILogger<TipoProdutoController> logger, ITipoProdutoAppService tipoProdutoAppService)
        {
            _logger = logger;
            _tipoProdutoAppService = tipoProdutoAppService;
        }

        [HttpPost]
        [Route("AdicionarTipoProdutoAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IEnumerable<TipoProdutoDTOResponse>> AdicionarTipoProdutoAsync([FromBody] TipoProdutoDTORequest tipoProdutoDTORequest)
        {
            await _tipoProdutoAppService.AdicionarAsync(tipoProdutoDTORequest);
            
            _logger.LogInformation("Categoria Tipo de Produto adicionado.");

            return await _tipoProdutoAppService.ListarAsync();

        }

        [HttpPut]
        [Route("AlterarTipoProdutoAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IEnumerable<TipoProdutoDTOResponse>> AlterarTipoProdutoAsync([FromBody] TipoProdutoDTORequest tipoProdutoDTORequest)
        {
            await _tipoProdutoAppService.AlterarAsync(tipoProdutoDTORequest);

            _logger.LogInformation($"Categoria Tipo de Produto {tipoProdutoDTORequest.Id} alterado.");

            return await _tipoProdutoAppService.ListarAsync();
        }

        [HttpDelete]
        [Route("ExcluirTipoProdutoAsync/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IEnumerable<TipoProdutoDTOResponse>> ExcluirTipoProdutoAsync([FromRoute] int id)
        {
            await _tipoProdutoAppService.ExcluirAsync(id);

            _logger.LogInformation($"Categoria Tipo de Produto {id} excluído.");

            return await _tipoProdutoAppService.ListarAsync();
        }

        [HttpGet]
        [Route("ObterTipoProdutoAsync/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<TipoProdutoDTOResponse> ObterTipoProdutoAsync([FromRoute] int id)
        {
            //Testing library HashidsNet
            EncriptDecriptHash(id);

            return await _tipoProdutoAppService.ObterAsync(id);

            static void EncriptDecriptHash(int id)
            {
                var guid = Guid.NewGuid();
                var hashId = new Hashids(salt: guid.ToString());
                var hash = hashId.Encode(number: id);
                var number = hashId.Decode(hash: hash);
            }
        }

        [HttpGet]
        [Route("ListarTipoProdutoAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IEnumerable<TipoProdutoDTOResponse>> ListarTipoProdutoAsync()
        {
            return await _tipoProdutoAppService.ListarAsync();
        }
    }
}
