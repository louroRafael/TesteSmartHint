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
            var model = new CustomerRegisterViewModel
            {
                CreatedAt = DateTime.Now
            };

            return View(model);
        }

        //[HttpPost]
        //public IActionResult Register(CustomerRegisterViewModel model)
        //{
        //    return View(model);
        //}

        [HttpPost]
        public IActionResult Register(CustomerRegisterViewModel customer)
        {
            if (ModelState.IsValid)
            {
                var model = _mapper.Map<Customer>(customer);

                if (model.Id == Guid.Empty)
                    _customerRepository.Add(model);
                else
                    _customerRepository.Update(model);

                return RedirectToAction("Index");
            }

            return View(customer);
        }
    }
}
