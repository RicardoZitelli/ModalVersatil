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

        [HttpPost("/AdicionarClienteAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

        [HttpPut("/AlterarClienteAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AlterarClienteAsync(ClienteDTORequest cliente)
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

        [HttpDelete("/ExcluirClienteAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ExcluirClienteAsync(int id)
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

        [HttpGet("/ObterClienteAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ClienteDTOResponse>> ObterClienteAsync(int id)
        {
            try
            {
                return Ok(JsonConvert.SerializeObject(await _clienteAppService.ObterAsync(id)));
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Erro catastrófico:. {JsonConvert.SerializeObject(ex.Message)}");

                return BadRequest(ex.Message); 
            }
           
        }

        [HttpGet("/ListarClienteAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
