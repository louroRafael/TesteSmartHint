using TesteSmartHint.Domain.Entities;
using TesteSmartHint.Domain.Interfaces.Common;

namespace TesteSmartHint.Domain.Interfaces
{
    public interface IConfigService : IServiceBase<Config>
    {
        Config? GetByName(string name);
    }
}
