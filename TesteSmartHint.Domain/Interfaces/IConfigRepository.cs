using TesteSmartHint.Domain.Entities;
using TesteSmartHint.Domain.Interfaces.Common;

namespace TesteSmartHint.Domain.Interfaces
{
    public interface IConfigRepository : IRepositoryBase<Config>
    {
        Config? GetByName(string name);
    }
}
