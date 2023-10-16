using System.Web.Helpers;
using TesteSmartHint.Domain.Entities;
using TesteSmartHint.Domain.Interfaces;
using TesteSmartHint.Infra.Context;
using TesteSmartHint.Infra.Repositories.Common;

namespace TesteSmartHint.Infra.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(MyContext context) : base(context)
        {
        }

        public Customer? GetByCpfCnpj(string cpfCnpj)
        {
            return _context.Customers.FirstOrDefault(x => x.CpfCnpj == cpfCnpj);
        }

        public Customer? GetByEmail(string email)
        {
            return _context.Customers.FirstOrDefault(x => x.Email == email);
        }

        public Customer? GetByStateRegistration(string stateRegistration)
        {
            return _context.Customers.FirstOrDefault(x => x.StateRegistration == stateRegistration);
        }
    }
}
