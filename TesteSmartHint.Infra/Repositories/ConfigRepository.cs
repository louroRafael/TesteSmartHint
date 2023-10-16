using TesteSmartHint.Domain.Entities;
using TesteSmartHint.Domain.Interfaces;
using TesteSmartHint.Infra.Context;
using TesteSmartHint.Infra.Repositories.Common;

namespace TesteSmartHint.Infra.Repositories
{
    public class ConfigRepository : RepositoryBase<Config>, IConfigRepository
    {
        public ConfigRepository(MyContext context) : base(context)
        {
        }

        public Config? GetByName(string name)
        {
            return _context.Configs.FirstOrDefault(x => x.Name == name);
        }
    }
}
