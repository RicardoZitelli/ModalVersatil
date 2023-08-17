using Microsoft.AspNetCore.Mvc;
using ModaVersatilApplication.DTOs.Request;
using ModaVersatilApplication.DTOs.Response;
using ModaVersatilApplication.Interfaces;
using AutoMapper;
using ModaVersatilDomain.Models;

namespace ModaVersatil.Controllers
{
    public class VendaController : ControllerBase
    {
        private readonly ILogger<VendaController> _logger;
        private readonly IVendaAppService _vendaAppService;
        private readonly ICarrinhoAppService _carrinhoAppService;
        private readonly IMapper _mapper;

        public VendaController(ILogger<VendaController> logger, IVendaAppService vendaAppService, ICarrinhoAppService carrinhoAppService, IMapper mapper)
        {
            _logger = logger;
            _vendaAppService = vendaAppService;
            _carrinhoAppService = carrinhoAppService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("AdicionarAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AdicionarAsync([FromBody] VendaDTORequest venda)
        {
            try
            {
                await _vendaAppService.AdicionarAsync(venda);
                
                _logger.LogInformation($"Venda criada com sucesso. {Newtonsoft.Json.JsonConvert.SerializeObject(venda)}");

                var listaVendaDTOResponse = await _vendaAppService.ListarPorClienteAsync(venda.ClienteId);

                var listaCarrinhoDTOResponse = await _carrinhoAppService.ListarPorClienteAsync(venda.ClienteId);

                foreach(var carrinhoDTOResponse in listaCarrinhoDTOResponse.Where(x=>x.VendaId == null))
                {
                    var carrinho = _mapper.Map<Carrinho>(carrinhoDTOResponse);
                    var carrinhoDTORequest = _mapper.Map<CarrinhoDTORequest>(carrinho);

                    carrinhoDTORequest.VendaId = listaVendaDTOResponse.OrderByDescending(x => x.DataCadastro).FirstOrDefault().Id;                    
                    
                    await _carrinhoAppService.AlterarAsync(carrinhoDTORequest);

                    _logger.LogInformation($"Produto do carrinho foi adicionado a venda. {Newtonsoft.Json.JsonConvert.SerializeObject(carrinhoDTORequest)}");
                }

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("EstornarVendaAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<IActionResult> EstornarVendaAsync([FromBody] VendaDTORequest venda)
        {
            try
            {
                await _vendaAppService.AlterarAsync(venda);
                
                var tipoVenda = "realizada";

                if(venda.Estornado != null)
                    tipoVenda = (bool)venda.Estornado ? "estornada" : "realizada";
                
                _logger.LogInformation($@"Venda { tipoVenda } com sucesso. Valor: R${venda.Total:N2}");

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ListarVendaPorClienteAsync/{clienteId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<IEnumerable<VendaDTOResponse>> ListarVendaPorClienteAsync([FromRoute] int clienteId)
        {                   
            return await _vendaAppService.ListarPorClienteAsync(clienteId);               
        }

        [HttpGet]
        [Route("ListarVendaPorClienteAsync/{dataInicio}/{dataFim}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<IEnumerable<VendaDTOResponse>> ListarVendaPorPeriodoAsync([FromRoute] DateTime dataInicio,DateTime dataFim)
        {
            return await _vendaAppService.ListarPorPeriodoAsync(dataInicio, dataFim);
        }
    }
}
