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
               return BadRequest(ex.Message);                
            }
           
        }

        [HttpPut("/AlterarClienteAsync")]
        public async Task AlterarClienteAsync(ClienteDTORequest cliente)
        {
            await _clienteAppService.AlterarAsync(cliente);

            _logger.LogInformation("Cliente alterado");
        }

        [HttpDelete("/ExcluirClienteAsync")]
        public async Task ExcluirClienteAsync(int id)
        {
            var cliente = await _clienteAppService.ObterAsync(id);

            if (cliente == null)
                _logger.LogInformation($"Cliente não encontrado. Id: {id}");
            
            await _clienteAppService.ExcluirAsync(id);
            
            _logger.LogInformation($"Cliente excluído. {JsonConvert.SerializeObject(cliente)}");                
        }

        [HttpGet("/ObterClienteAsync")]
        public async Task<ClienteDTOResponse> ObterClienteAsync(int id)
        {
            return await _clienteAppService.ObterAsync(id);
        }

        [HttpGet("/ListarClienteAsync")]
        public async Task<IEnumerable<ClienteDTOResponse>> ListarClienteAsync()
        {
            return await _clienteAppService.ListarAsync();
        }
    }
}
