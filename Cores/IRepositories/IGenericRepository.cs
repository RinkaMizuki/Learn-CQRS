namespace Learn_CQRS.Core.Repostories
{
    public interface IGenericRepository<T> where T : class //Class Constraint (T is reference type not primitive type)
    {
        public Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken);
        public Task<T?> GetById<Y>(Y id, CancellationToken cancellationToken);
        public Task<T> Add(T entity, CancellationToken cancellationToken);
        public T? Update(T entity);
        public bool Delete(T entity);
    }
}
