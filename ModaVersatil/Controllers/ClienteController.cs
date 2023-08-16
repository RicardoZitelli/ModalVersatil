using Microsoft.AspNetCore.Mvc;
using ModaVersatilApplication.DTOs.Request;
using ModaVersatilApplication.DTOs.Response;
using ModaVersatilApplication.Interfaces;
using Newtonsoft.Json;

namespace ModaVersatil.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly IClienteAppService _clienteAppService;
        public ClienteController(ILogger<ClienteController> logger, IClienteAppService clienteAppService)
        {
            _logger = logger;
            _clienteAppService = clienteAppService;
        }

        [HttpPost]
        [Route("AdicionarClienteAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AdicionarClienteAsync(ClienteDTORequest cliente)
        {
            try
            {
                await _clienteAppService.AdicionarAsync(cliente);

                _logger.LogInformation("Cliente adicionado");

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Erro catastrófico:. {JsonConvert.SerializeObject(ex.Message)}");

                return BadRequest(ex.Message);                
            }
           
        }

        [HttpPut]
        [Route("AlterarClienteAsync")]       
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AlterarClienteAsync([FromBody] ClienteDTORequest cliente)
        {
            try
            {
                await _clienteAppService.AlterarAsync(cliente);

                _logger.LogInformation("Cliente alterado");
                
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Erro catastrófico:. {JsonConvert.SerializeObject(ex.Message)}");

                return BadRequest(ex.Message);
            }
            
        }

        [HttpDelete]
        [Route("ExcluirClienteAsync/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ExcluirClienteAsync([FromRoute]int id)
        {
            try
            {
                var cliente = await _clienteAppService.ObterAsync(id);

                if (cliente == null)
                    _logger.LogInformation($"Cliente não encontrado. Id: {id}");

                await _clienteAppService.ExcluirAsync(id);

                _logger.LogInformation($"Cliente excluído. {JsonConvert.SerializeObject(cliente)}");

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Erro catastrófico:. {JsonConvert.SerializeObject(ex.Message)}");

                return BadRequest(ex.Message);
            }
                        
        }

        [HttpGet]
        [Route("ObterClienteAsync/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ClienteDTOResponse>> ObterClienteAsync([FromRoute] int id)
        {
            try
            {
                return Ok(JsonConvert.SerializeObject(await _clienteAppService.ObterAsync(id)));
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Erro catastrófico: {JsonConvert.SerializeObject(ex.Message)}");

                return BadRequest(ex.Message); 
            }
           
        }

        [HttpGet]
        [Route("ListarClienteAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ClienteDTOResponse>>> ListarClienteAsync()
        {
            try
            {
                return Ok(JsonConvert.SerializeObject(await _clienteAppService.ListarAsync()));
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Erro catastrófico:. {JsonConvert.SerializeObject(ex.Message)}");

                return BadRequest(ex.Message);
            }                    }
    }
}
