using TesteSmartHint.Domain.Entities;
using TesteSmartHint.Domain.Interfaces;
using TesteSmartHint.Domain.Interfaces.Common;

namespace TesteSmartHint.Domain.Services.Common
{
    public abstract class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;
        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public void Add(TEntity entity) => _repository.Add(entity);

        public void Delete(TEntity entity) => _repository.Delete(entity);

        public IEnumerable<TEntity> GetAll() => _repository.GetAll();

        public TEntity GetById(Guid id) => _repository.GetById(id);

        public void Update(TEntity entity) => _repository.Update(entity);
    }
}
