using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using TesteSmartHint.Domain.Entities;
using TesteSmartHint.Domain.Enums;
using TesteSmartHint.Domain.Interfaces;
using TesteSmartHint.Web.ViewModels.Customer;

namespace TesteSmartHint.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(
            ICustomerService customerService,
            IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var customers = _customerService.GetAll().Select(x => _mapper.Map<CustomerViewModel>(x));
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

        [HttpPost]
        public IActionResult Register(CustomerRegisterViewModel customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = _mapper.Map<Customer>(customer);

                    if (!_customerService.ValidateEmail(model.Email))
                        throw new Exception("Este e-mail já está cadastrado para outro Cliente");

                    if(!_customerService.ValidateCpfCnpj(model.CpfCnpj))
                        throw new Exception("Este CPF/CNPJ já está cadastrado para outro Cliente");

                    if(model.Type == PersonType.LegalPerson && !model.Exempt)
                        if(!_customerService.ValidateStateRegistration(model.StateRegistration))
                            throw new Exception("Esta Inscrição Estadual já está cadastrada para outro Cliente");

                    if (model.Id == Guid.Empty)
                        _customerService.Add(model);
                    else
                        _customerService.Update(model);

                    TempData["SuccessMessage"] = "Cliente cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(customer);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View(customer);
            }
        }
    }
}
