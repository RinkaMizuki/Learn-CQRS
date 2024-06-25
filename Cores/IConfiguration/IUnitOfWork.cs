using Learn_CQRS.Core.Repositories;

namespace Learn_CQRS.Core.IConfiguration
{
    public interface IUnitOfWork
    {
        //Container All Repositories
        IHeroRepository Heros { get; }
        Task CompleteAsync(CancellationToken cancellationToken);
    }
}
