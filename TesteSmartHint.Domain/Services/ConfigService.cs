using TesteSmartHint.Domain.Entities;
using TesteSmartHint.Domain.Interfaces;
using TesteSmartHint.Domain.Services.Common;

namespace TesteSmartHint.Domain.Services
{
    public class ConfigService : ServiceBase<Config>, IConfigService
    {
        private readonly IConfigRepository _repository;
        public ConfigService(IConfigRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public Config? GetByName(string name) => _repository.GetByName(name);
    }
}
