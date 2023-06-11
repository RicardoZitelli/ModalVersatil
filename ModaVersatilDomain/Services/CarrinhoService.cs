using ModaVersatilDomain.Interfaces.Services;
using ModaVersatilDomain.Interfaces.UnitOfWork;
using ModaVersatilDomain.Models;
using ModaVersatilDomain.Services.Base;

namespace ModaVersatilDomain.Services
{
    public class CarrinhoService : ServiceBase, ICarrinhoService
    {
        public CarrinhoService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task AdicionarAsync(Carrinho carrinho)
        {
            await UnitOfWork.CarrinhoRepository.AdicionarAsync(carrinho);
        }

        public async Task AlterarAsync(Carrinho carrinho)
        {
            await UnitOfWork.CarrinhoRepository.AlterarAsync(carrinho);
        }

        public async Task ExcluirAsync(int id)
        {
            await UnitOfWork.CarrinhoRepository.ExcluirAsync(id);
        }

        public async Task<IEnumerable<Carrinho>> ListarAsync()
        {
            return await UnitOfWork.CarrinhoRepository.ListarAsync();
        }

        public async Task<Carrinho> ObterAsync(int id)
        {
            return await UnitOfWork.CarrinhoRepository.ObterAsync(id);
        }
    }
}
