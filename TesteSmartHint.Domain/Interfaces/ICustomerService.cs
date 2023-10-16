using TesteSmartHint.Domain.DTO;
using TesteSmartHint.Domain.Entities;
using TesteSmartHint.Domain.Interfaces.Common;

namespace TesteSmartHint.Domain.Interfaces
{
    public interface ICustomerService : IServiceBase<Customer>
    {
        IEnumerable<Customer> GetByFilter(CustomerFilter filter);

        bool ValidateEmail(string email, Guid id);

        bool ValidateCpfCnpj(string cpfCnpj, Guid id);

        bool ValidateStateRegistration(string stateRegistration, Guid id);
    }
}
