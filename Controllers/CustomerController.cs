using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using TesteSmartHint.Domain.DTO;
using TesteSmartHint.Domain.Entities;
using TesteSmartHint.Domain.Enums;
using TesteSmartHint.Domain.Interfaces;
using TesteSmartHint.Web.ViewModels.Customer;

namespace TesteSmartHint.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IConfigService _configService;
        private readonly IMapper _mapper;

        public CustomerController(
            ICustomerService customerService,
            IConfigService configService,
            IMapper mapper)
        {
            _customerService = customerService;
            _configService = configService;
            _mapper = mapper;
        }

        public IActionResult Index(CustomerFilterViewModel Filter)
        {
            var customers = _customerService.GetByFilter(_mapper.Map<CustomerFilter>(Filter)).Select(x => _mapper.Map<CustomerViewModel>(x));
            var pagedResult = new PagedResult<CustomerViewModel>(customers, Filter.Page);

            return View(pagedResult);
        }

        public IActionResult Register()
        {
            var model = new CustomerRegisterViewModel
            {
                CreatedAt = DateTime.Now,
                StateRegistrationForNaturalPerson = _configService.GetByName("StateRegistrationForNaturalPerson")?.Value ?? false
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Register(CustomerRegisterViewModel customer)
        {
            try
            {
                var stateRegistrationForNaturalPerson = _configService.GetByName("StateRegistrationForNaturalPerson")?.Value ?? false;

                if (ModelState.IsValid)
                {
                    var model = _mapper.Map<Customer>(customer);

                    if (!_customerService.ValidateEmail(model.Email, model.Id))
                        throw new Exception("Este e-mail já está cadastrado para outro Cliente");

                    if(!_customerService.ValidateCpfCnpj(model.CpfCnpj, model.Id))
                        throw new Exception("Este CPF/CNPJ já está cadastrado para outro Cliente");

                    if((model.Type == PersonType.LegalPerson || stateRegistrationForNaturalPerson) && !model.Exempt)
                        if(!_customerService.ValidateStateRegistration(model.StateRegistration, model.Id))
                            throw new Exception("Esta Inscrição Estadual já está cadastrada para outro Cliente");

                    if (model.Id == Guid.Empty)
                        _customerService.Add(model);
                    else
                    {
                        var entity = _customerService.GetById(model.Id);

                        entity.Name = model.Name;
                        entity.Email = model.Email;
                        entity.Phone = model.Phone;
                        entity.Type = model.Type;
                        entity.CpfCnpj = model.CpfCnpj;
                        entity.StateRegistration = model.StateRegistration;
                        entity.Exempt = model.Exempt;
                        entity.Gender = model.Gender;
                        entity.Birth = model.Birth;
                        entity.Blocked = model.Blocked;
                        entity.Password = model.Password;

                        _customerService.Update(entity);
                    }

                    TempData["SuccessMessage"] = $"Cliente {(customer.Id == Guid.Empty ? "cadastrado" : "alterado")} com sucesso!";
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

        public IActionResult Edit(Guid id)
        {
            var customer = _mapper.Map<CustomerRegisterViewModel>(_customerService.GetById(id));
            customer.PasswordConfirm = customer.Password;
            customer.StateRegistrationForNaturalPerson = _configService.GetByName("StateRegistrationForNaturalPerson")?.Value ?? false;

            return View("Register", customer);
        }
    }
}
