using System.Globalization;
using TesteSmartHint.Domain.DTO;
using TesteSmartHint.Domain.Entities;
using TesteSmartHint.Domain.Interfaces;
using TesteSmartHint.Domain.Services.Common;

namespace TesteSmartHint.Domain.Services
{
    public class CustomerService : ServiceBase<Customer>, ICustomerService
    {
        private readonly ICustomerRepository _repository;
        public CustomerService(ICustomerRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public IEnumerable<Customer> GetByFilter(CustomerFilter filter)
        {
            var customers = _repository.GetAll();

            if (!string.IsNullOrEmpty(filter.ByName))
                customers = customers.Where(x => x.Name.Contains(filter.ByName));

            if (!string.IsNullOrEmpty(filter.ByEmail))
                customers = customers.Where(x => x.Email.Contains(filter.ByEmail));

            if (!string.IsNullOrEmpty(filter.ByPhone))
                customers = customers.Where(x => x.Phone.Contains(filter.ByPhone));

            if (!string.IsNullOrEmpty(filter.ByDate))
            {
                var splitDate = filter.ByDate.Split(" - ");
                var initialDate = DateTime.ParseExact(splitDate[0], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                var finalDate = DateTime.ParseExact(splitDate[1], "dd/MM/yyyy", CultureInfo.InvariantCulture);

                customers = customers.Where(x => x.CreatedAt >= initialDate && x.CreatedAt <= finalDate);
            }

            if (filter.ByBlocked != null)
                customers = customers.Where(x => x.Blocked == filter.ByBlocked);

            return customers;
        }

        public bool ValidateCpfCnpj(string cpfCnpj, Guid id)
        {
            var customer = _repository.GetByCpfCnpj(cpfCnpj);
            return customer == null || customer?.Id == id;
        }

        public bool ValidateEmail(string email, Guid id)
        {
            var customer = _repository.GetByEmail(email);
            return customer == null || customer?.Id == id;
        }

        public bool ValidateStateRegistration(string stateRegistration, Guid id)
        {
            var customer = _repository.GetByStateRegistration(stateRegistration);
            return customer == null || customer?.Id == id;
        }
    }
}
