using ModaVersatilDomain.Interfaces.Services;
using ModaVersatilDomain.Interfaces.UnitOfWork;
using ModaVersatilDomain.Models;
using ModaVersatilDomain.Services.Base;

namespace ModaVersatilDomain.Services
{
    public class TipoProdutoService : ServiceBase, ITipoProdutoService
    {

        public TipoProdutoService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task AdicionarAsync(TipoProduto tipoProduto)
        {
            await UnitOfWork.TipoProdutoRepository.AdicionarAsync(tipoProduto);
        }

        public async Task AlterarAsync(TipoProduto tipoProduto)
        {
            await UnitOfWork.TipoProdutoRepository.AlterarAsync(tipoProduto);
        }

        public async Task ExcluirAsync(int id)
        {
            await UnitOfWork.TipoProdutoRepository.ExcluirAsync(id);
        }

        public async Task<IEnumerable<TipoProduto>> ListarAsync()
        {
            return await UnitOfWork.TipoProdutoRepository.ListarAsync();
        }

        public async Task<TipoProduto> ObterAsync(int id)
        {
            return await UnitOfWork.TipoProdutoRepository.ObterAsync(id);
        }
    }
}
