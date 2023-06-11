using ModaVersatilDomain.Interfaces.Services;
using ModaVersatilDomain.Interfaces.UnitOfWork;
using ModaVersatilDomain.Models;
using ModaVersatilDomain.Services.Base;

namespace ModaVersatilDomain.Services
{
    public class ClienteService : ServiceBase, IClienteService
    {
        public ClienteService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task AdicionarAsync(Cliente cliente)
        {
            await UnitOfWork.ClienteRepository.AdicionarAsync(cliente);
        }

        public async Task AlterarAsync(Cliente cliente)
        {
            await UnitOfWork.ClienteRepository.AlterarAsync(cliente);
        }

        public async Task ExcluirAsync(int id)
        {
            await UnitOfWork.ClienteRepository.ExcluirAsync(id);
        }

        public async Task<IEnumerable<Cliente>> ListarAsync()
        {
            return await UnitOfWork.ClienteRepository.ListarAsync();
        }

        public async Task<Cliente> ObterAsync(int id)
        {
            return await UnitOfWork.ClienteRepository.ObterAsync(id);
        }
    }
}
