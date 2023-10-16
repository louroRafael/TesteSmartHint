using TesteSmartHint.Domain.Entities;

namespace TesteSmartHint.Domain.Interfaces.Common
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
    }
}
