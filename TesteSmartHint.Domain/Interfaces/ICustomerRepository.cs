using TesteSmartHint.Domain.Entities;
using TesteSmartHint.Domain.Interfaces.Common;

namespace TesteSmartHint.Domain.Interfaces
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        Customer? GetByEmail(string email);

        Customer? GetByCpfCnpj(string cpfCnpj);

        Customer? GetByStateRegistration(string stateRegistration);
    }
}
