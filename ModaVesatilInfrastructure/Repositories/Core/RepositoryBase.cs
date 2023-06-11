using System.Data;

namespace ModaVesatilInfrastructure.Repositories.Core
{
    public abstract class RepositoryBase : IDisposable
    {
        private bool _disposed { get; set; }
        private IDbConnection _connection;
        
        protected IDbConnection Connection { get { return _connection; } }

        protected RepositoryBase(IDbConnection connection)
        {
            _connection = connection;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(!_disposed)
            {
                Dispose();
            }
            _disposed = true;
        }
    }
}
