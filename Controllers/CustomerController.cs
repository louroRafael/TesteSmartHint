using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TesteSmartHint.Domain.Entities;
using TesteSmartHint.Domain.Interfaces;
using TesteSmartHint.Web.ViewModels.Customer;

namespace TesteSmartHint.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerController(
            ICustomerRepository customerRepository,
            IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var customers = _customerRepository.GetAll().Select(x => _mapper.Map<CustomerViewModel>(x));
            return View(customers);
        }

        public IActionResult Register()
        {
            var model = new CustomerViewModel
            {
                CreatedAt = DateTime.Now
            };

            return View(model);
        }

        public IActionResult Save(CustomerViewModel customer)
        {
            var model = _mapper.Map<Customer>(customer);

            if (model.Id == Guid.Empty)
                _customerRepository.Add(model);
            else
                _customerRepository.Update(model);

            return RedirectToAction("Index");
        }
    }
}
