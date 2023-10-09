using AutoMapper;
using TesteSmartHint.Domain.Entities;
using TesteSmartHint.Web.ViewModels.Customer;

namespace TesteSmartHint.Web.Mapper
{
    public class CustomerMapProfile : Profile
    {
        public CustomerMapProfile()
        {
            CreateMap<CustomerViewModel, Customer>();
            CreateMap<CustomerRegisterViewModel, Customer>();

            CreateMap<Customer, CustomerViewModel>();
        }
    }
}
