using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TesteSmartHint.Domain.Entities;
using TesteSmartHint.Domain.Interfaces;
using TesteSmartHint.Domain.Services;
using TesteSmartHint.Web.ViewModels.Config;

namespace TesteSmartHint.Web.Controllers
{
    public class ConfigController : Controller
    {
        private readonly IConfigService _configService;
        private readonly IMapper _mapper;

        public ConfigController(
            IConfigService configService,
            IMapper mapper
        )
        {
            _configService = configService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var config = _mapper.Map<ConfigViewModel>(_configService.GetByName("StateRegistrationForNaturalPerson"));
            return View(config);
        }

        [HttpPost]
        public IActionResult Save(ConfigViewModel model)
        {
            var entity = _configService.GetById(model.Id);
            entity.Value = model.Value;
            _configService.Update(entity);

            TempData["SuccessMessage"] = $"Configurações salvas!";

            return RedirectToAction("Index", "Customer");
        }
    }
}
