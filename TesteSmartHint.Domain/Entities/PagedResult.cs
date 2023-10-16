using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteSmartHint.Domain.Entities
{
    public class PagedResult<TEntity>
    {
        public PagedResult(IEnumerable<TEntity> items, int currentPage = 1)
        {
            Items = items
                        .Skip((currentPage - 1) * PageSize)
                        .Take(PageSize);
            TotalItems = items.Count();
            CurrentPage = currentPage;
        }

        public virtual int CurrentPage { get; set; }
        public virtual int PageSize { get; set; } = 20;
        public virtual int TotalItems { get; set; }
        public virtual int TotalPages => (int)Math.Ceiling(decimal.Divide(TotalItems, PageSize));
        public virtual bool EnablePrevious => CurrentPage > 1;
        public virtual bool EnableNext => CurrentPage < TotalPages;

        public virtual IEnumerable<TEntity> Items { get; set; }
    }
}
