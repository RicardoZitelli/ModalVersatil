using ModaVersatilDomain.Interfaces.Repositories;
using ModaVersatilDomain.Interfaces.UnitOfWork;
using ModaVesatilInfrastructure.Repositories;
using System.Data;

namespace ModaVesatilInfrastructure.Uow
{
    public class UnitOfWork : IUnitOfWork
    {

        private IDbConnection _connection;
        private IDbTransaction _dbTransaction;
        private bool disposedValue;

        public UnitOfWork(IDbConnection dbConnection) => _connection = dbConnection;

        public ITipoProdutoRepository TipoProdutoRepository => new TipoProdutoRepository(_connection);

        public IProdutoRepository ProdutoRepository => new ProdutoRepository(_connection);

        public IClienteRepository ClienteRepository => new ClienteRepository(_connection);

        public ICarrinhoRepository CarrinhoRepository => new CarrinhoRepository(_connection);

        public IVendaRepository VendaRepository => new VendaRepository(_connection);
        
        public void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (_connection != null)
                    {
                        if (_connection.State != ConnectionState.Closed)
                            _connection.Close();

                        _connection.Dispose();
                        _connection = null;
                    }

                    if (_dbTransaction != null)
                    {
                        _dbTransaction.Dispose();
                        _dbTransaction = null;
                    }
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
