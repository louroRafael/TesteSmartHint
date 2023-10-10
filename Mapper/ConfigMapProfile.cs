using AutoMapper;
using TesteSmartHint.Domain.Entities;
using TesteSmartHint.Web.ViewModels.Config;
using TesteSmartHint.Web.ViewModels.Customer;

namespace TesteSmartHint.Web.Mapper
{
    public class ConfigMapProfile : Profile
    {
        public ConfigMapProfile()
        {
            CreateMap<ConfigViewModel, Config>();
            CreateMap<Config, ConfigViewModel>();
        }
    }
}
