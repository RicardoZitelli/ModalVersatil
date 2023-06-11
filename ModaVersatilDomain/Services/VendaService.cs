using ModaVersatilDomain.Interfaces.Services;
using ModaVersatilDomain.Interfaces.UnitOfWork;
using ModaVersatilDomain.Models;
using ModaVersatilDomain.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModaVersatilDomain.Services
{
    public class VendaService : ServiceBase, IVendaService
    {
        public VendaService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public async Task AdicionarAsync(Venda venda)
        {
            await UnitOfWork.VendaRepository.AdicionarAsync(venda);
        }

        public async Task AlterarAsync(Venda venda)
        {
            var vendaRealizada = await ObterAsync(venda.Id);

            //Impedir de alterar dados fixos
            venda.Total = vendaRealizada.Total;
            venda.ClienteId = vendaRealizada.ClienteId;
            venda.DataCadastro = vendaRealizada.DataCadastro;

            await UnitOfWork.VendaRepository.AlterarAsync(venda);
        }
        
        public async Task<IEnumerable<Venda>> ListarAsync()
        {
            return await UnitOfWork.VendaRepository.ListarAsync();
        }

        public Task<IEnumerable<Venda>> ListarPorClienteAsync(int clienteId)
        {
            return UnitOfWork.VendaRepository.ListarPorClienteAsync(clienteId);
        }

        public Task<IEnumerable<Venda>> ListarPorPeriodoAsync(DateTime dataInicio, DateTime dataFim)
        {
            return UnitOfWork.VendaRepository.ListarPorPeriodoAsync(dataInicio, dataFim);
        }

        public async Task<Venda> ObterAsync(int id)
        {
            return await UnitOfWork.VendaRepository.ObterAsync(id);
        }
    }
}
