using Learn_CQRS.Core.IConfiguration;
using Learn_CQRS.Core.Repositories;
using Learn_CQRS.Data;

namespace Learn_CQRS.Datas
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private bool disposedValue;
        private readonly ILogger _logger;
        private readonly HeroDbContext _dbContext;
        public IHeroRepository Heros { get; private set; }
        public UnitOfWork(HeroDbContext dbContext, ILoggerFactory loggerFactory)
        {
            _dbContext = dbContext;
            _logger = loggerFactory.CreateLogger("logs");
            Heros = new HeroRepository(_dbContext, _logger);
        }
        public async Task CompleteAsync(CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    _dbContext.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~UnitOfWork()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
