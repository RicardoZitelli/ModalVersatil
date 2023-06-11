using ModaVersatilDomain.Interfaces.Services;
using ModaVersatilDomain.Interfaces.UnitOfWork;
using ModaVersatilDomain.Models;
using ModaVersatilDomain.Services.Base;

namespace ModaVersatilDomain.Services
{
    public class ProdutoService : ServiceBase, IProdutoService
    {
        public ProdutoService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task AdicionarAsync(Produto produto)
        {
            await UnitOfWork.ProdutoRepository.AdicionarAsync(produto);
        }

        public async Task AlterarAsync(Produto produto)
        {
            await UnitOfWork.ProdutoRepository.AlterarAsync(produto);
        }

        public async Task ExcluirAsync(int id)
        {
            await UnitOfWork.ProdutoRepository.ExcluirAsync(id);
        }

        public async Task<IEnumerable<Produto>> ListarAsync()
        {
            return await UnitOfWork.ProdutoRepository.ListarAsync();
        }

        public async Task<Produto> ObterAsync(int id)
        {
            return await UnitOfWork.ProdutoRepository.ObterAsync(id);
        }
    }
}
