using AutoMapper;
using TesteSmartHint.Domain.DTO;
using TesteSmartHint.Domain.Entities;
using TesteSmartHint.Web.ViewModels.Customer;

namespace TesteSmartHint.Web.Mapper
{
    public class CustomerMapProfile : Profile
    {
        public CustomerMapProfile()
        {
            CreateMap<CustomerRegisterViewModel, Customer>();
            CreateMap<Customer, CustomerRegisterViewModel>();

            CreateMap<Customer, CustomerViewModel>()
                .ForMember(vm => vm.CreatedAt, op => op.MapFrom(e => e.CreatedAt.ToString("dd/MM/yyyy")));

            CreateMap<CustomerFilterViewModel, CustomerFilter>();
        }
    }
}
