using Microsoft.EntityFrameworkCore;
using TesteSmartHint.Domain.Entities;
using TesteSmartHint.Domain.Interfaces.Common;
using TesteSmartHint.Infra.Context;

namespace TesteSmartHint.Infra.Repositories.Common
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        protected MyContext _context;
        protected DbSet<TEntity> _set;

        public RepositoryBase(MyContext context)
        {
            _context = context;
            _set = _context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _set.Add(entity);
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _set.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _set.Remove(entity);
            _context.SaveChanges();
        }

        public TEntity GetById(Guid id)
        {
            return _set.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _set.AsNoTracking().ToList();
        }
    }
}
